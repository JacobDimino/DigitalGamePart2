using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    [SerializeField] GameObject[] colors;
    [SerializeField] private AudioClip[] spawnSFXs;
    [SerializeField] public AudioClip[] deathSFXs;

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
        //check to see if we should spawn
        if (Time.time > nextSpawnTime)
        {
            SoundManager.instance.PlayRandomSfxClip(spawnSFXs, transform, 1f);

            //should make it a function called spawn but im lazy
            //get a random enemy object and spawn it at a random spawn point
            manager.allOrbs.Add(Instantiate(colors[Random.Range(0, colors.Length)], 
                spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity));


            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
