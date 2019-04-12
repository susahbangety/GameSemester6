using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSpawn : MonoBehaviour
{
    public Spawner[] Spawn;
    public float timeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("spawningDart", timeSpawn, timeSpawn);
    }

    void spawningDart()
    {
        int dartIndex = Random.Range(0, 100);

        //Instantiate(Darts, spawning[dartIndex].transform.position, spawning[dartIndex].transform.rotation);
        for (int i = 0; i < Spawn.Length; i++)
        {
            if(dartIndex >= Spawn[i].minProbabilitySpawn && dartIndex <= Spawn[i].maxProbabilitySpawn)
            {
                Instantiate(Spawn[i].Darts, Spawn[i].spawning.transform.position, Spawn[i].spawning.transform.rotation);
                break;
            }
        }
    }

    [System.Serializable]
    public class Spawner
    {
        public GameObject Darts;
        public Transform spawning;
        public int minProbabilitySpawn;
        public int maxProbabilitySpawn;
    }
}
