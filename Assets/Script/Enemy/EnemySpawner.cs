using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform Origin;
    [SerializeField] private GameObject Enemey;

    [SerializeField] private float SpawnRate = 10f;
    [SerializeField] private float SpawnRadius = 10f;
    void Start()
    {
        //Spawn Enemies
        InvokeRepeating("Spawn", 0f, SpawnRate);

    }

    private void Spawn()
    {
        Vector2 RandomSpawnPosition = Random.insideUnitCircle.normalized * SpawnRadius;

        Vector3 SpawnPosition = Origin.position + new Vector3(RandomSpawnPosition.x, RandomSpawnPosition.y, 0);

        Instantiate(Enemey, SpawnPosition, Quaternion.identity);
    }
}
