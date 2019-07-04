using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSpawn : MonoBehaviour
{
    public List<dartSpawn> dartspawn = new List<dartSpawn>();
    public GameObject dartObject;
    public Rigidbody rgb;
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
        InvokeRepeating("dartSpawning", timeToSpawn, timeToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        //dartObject.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
    }

    void dartSpawning()
    {
        for (int i = 0; i < dartspawn.Count; i++)
        {
            if (Random.value * 100 < dartspawn[i].spawnChance)
            {
                Instantiate(dartObject, dartspawn[i].spawnPos.transform.position, dartspawn[i].spawnPos.transform.rotation);
                Debug.Log(dartObject.name + " has spawned in the location " + dartspawn[i].spawnPos);
                Debug.Log("Spawn chance is : " + dartspawn[i].spawnChance + "%");
                //DestroyImmediate(dartObject, true);
                //Destroy(dartObject, 2f);
            }
        }
    }

    [System.Serializable]
    public class dartSpawn
    {
        public Transform spawnPos;
        public float spawnChance;
    }
}
