using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform Origin;
    [SerializeField] private GameObject Enemey;
    [SerializeField] private int HiveHealth = 10;
    [SerializeField] private float SpawnRate = 10f;
    [SerializeField] private float SpawnRadius = 10f;
    [SerializeField] private PlayerManager player;
    private AudioSource source;
    void Start()
    {
        //gets audio source
        source = GetComponent<AudioSource>();

        //Spawn Enemies
        InvokeRepeating("Spawn", 0f, SpawnRate);

    }
    void Update()
    {
        if (HiveHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Spawn()
    {
        Vector2 RandomSpawnPosition = Random.insideUnitCircle.normalized * SpawnRadius;

        Vector3 SpawnPosition = Origin.position + new Vector3(RandomSpawnPosition.x, RandomSpawnPosition.y, 0);

        Instantiate(Enemey, SpawnPosition, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            //plays sound effect when shot
            source.Play();
            HiveHealth--;
            Destroy(collision.gameObject);
        }
    }
}
