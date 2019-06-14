using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public List<Transform> possibleSpike = new List<Transform>();
    public GameObject Spike;
    public Transform[] spawnPoints;
    public float hasSpawning;
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            possibleSpike.Add(spawnPoints[i]);
        }

        InvokeRepeating("randomSpawnSpike", hasSpawning, hasSpawning);
    }

    void randomSpawnSpike()
    {
        if(possibleSpike.Count > 0)
        {
            int spawnIndex = Random.Range(0, possibleSpike.Count);
            GameObject NewSpike = Instantiate(Spike, possibleSpike[spawnIndex].position, possibleSpike[spawnIndex].rotation);
            NewSpike.GetComponent<spikeSpawner>().spikeSpawnPoints = possibleSpike[spawnIndex];

            possibleSpike.RemoveAt(spawnIndex);
        }
    }
}
