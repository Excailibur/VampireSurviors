using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Transform Origin;
    [SerializeField] private GameObject Enemey;
    [SerializeField] private GameObject Hive;

    [SerializeField] private float SpawnRate = 10f;
    [SerializeField] private float SpawnRadius = 5f;

    [SerializeField] private float HiveSpawnRate = 10f;
    [SerializeField] private float HiveSpawnRadius = 20f;
    void Start()
    {
        //Spawn Enemies
        InvokeRepeating("Spawn", SpawnRate, SpawnRate);
        InvokeRepeating("SpawnHive", HiveSpawnRate, HiveSpawnRate);
    }

    private void Spawn()
    {
        Vector2 RandomSpawnPosition = Random.insideUnitCircle.normalized * SpawnRadius;

        Vector3 SpawnPosition = Origin.position + new Vector3(RandomSpawnPosition.x, RandomSpawnPosition.y, 0);

        Instantiate(Enemey, SpawnPosition, Quaternion.identity);
    }

    private void SpawnHive()
    {
        Vector2 RandomSpawnPosition = Random.insideUnitCircle.normalized * SpawnRadius;

        Vector3 SpawnPosition = Origin.position + new Vector3(RandomSpawnPosition.x, RandomSpawnPosition.y, 0);

        Instantiate(Hive, SpawnPosition, Quaternion.identity);
    }
}
