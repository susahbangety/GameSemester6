using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawn : MonoBehaviour
{
    public List<spikeSpawn> spikespawn = new List<spikeSpawn>();
    public GameObject spikeObject;
    public int timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < DartSpawn.Count; i++)
        //{
        //    if(Random.value * 100 < DartSpawn[i].spawnChance)
        //    {
        //        Instantiate(DartSpawn[i].dartObject, DartSpawn[i].spawnPos.transform.position, DartSpawn[i].spawnPos.transform.rotation);
        //        Debug.Log(DartSpawn[i].dartObject.name+ " has spawned in the location " +DartSpawn[i].spawnPos);
        //        Debug.Log("Spawn chance is : "+DartSpawn[i].spawnChance+ "%");
        //    }
        //}
        //StartCoroutine(DartSpawned());
        InvokeRepeating("spikeSpawning", timeToSpawn, timeToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        //dartObject.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
    }

    void spikeSpawning()
    {
        for (int i = 0; i < spikespawn.Count; i++)
        {
            if (Random.value * 100 < spikespawn[i].spawnChance)
            {
                Instantiate(spikeObject, spikespawn[i].spawnPos.transform.position, spikespawn[i].spawnPos.transform.rotation);
                Debug.Log(spikeObject.name + " has spawned in the location " + spikespawn[i].spawnPos);
                //DestroyImmediate(dartObject, true);
                //Destroy(dartObject, 2f);
            }
        }
    }

    [System.Serializable]
    public class spikeSpawn
    {
        public Transform spawnPos;
        public float spawnChance;
    }
}
