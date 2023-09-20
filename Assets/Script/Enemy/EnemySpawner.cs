using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject Enemey;

    [SerializeField] private float SpawnRate = 3f;
    [SerializeField] private float SpawnRadius = 10f;
    void Start()
    {
        //Finds the player Transform
        Player = GameObject.Find("Player").GetComponent<Transform>();

        //Spawn Enemies
        InvokeRepeating("Spawn", 0f, SpawnRate);

    }

    private void Spawn()
    {
        Vector2 RandomSpawnPosition = Random.insideUnitCircle.normalized * SpawnRadius;

        Vector3 SpawnPosition = Player.position + new Vector3(RandomSpawnPosition.x, RandomSpawnPosition.y, 0);

        Instantiate(Enemey, SpawnPosition, Quaternion.identity);
    }
}
