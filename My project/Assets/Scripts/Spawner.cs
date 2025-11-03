using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    [SerializeField] GameObject[] colors;

    Manager manager;


    public float timeBetweenSpawns;
    float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindAnyObjectByType<Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            //get a random color object and spawn it at a random spawn point
            manager.allOrbs.Add(Instantiate(colors[Random.Range(0, colors.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity));
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
