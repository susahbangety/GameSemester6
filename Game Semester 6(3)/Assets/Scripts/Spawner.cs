using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> possibleSpawns = new List<Transform>();
    public GameObject[] Weapon;
    public Transform[] spawnPos;
    //public Transform Equip;
    public float Spawning;

    int randomInt;
    int spawnIndex;
    void Awake()
    {
        //InvokeRepeating("spawnRandom", startSpawning, spawnDelay);
        //Instantiate(Weapon[randomInt], spawnPos[randomInt].position, spawnPos[randomInt].rotation);
        //spawnRandom();
        
        
        for (int i = 0; i < spawnPos.Length; i++)
        {
            possibleSpawns.Add(spawnPos[i]);
            //Debug.Log(" in Spawn Point " + spawnPos[i]);
            //Debug.Log(" "+Weapon[randomInt]);
        }
        
        InvokeRepeating("spawnRandom", Spawning, Spawning);
    }
    void spawnRandom()
    {
        if (possibleSpawns.Count > 0)
        {
            spawnIndex = Random.Range(0, possibleSpawns.Count);
            randomInt = Random.Range(0, Weapon.Length);
            GameObject NewWeapon = Instantiate(Weapon[randomInt], possibleSpawns[spawnIndex].position, possibleSpawns[spawnIndex].rotation) as GameObject;
            //GameObject NewWeapon = Instantiate(Weapon[randomInt], possibleSpawns[randomInt].position, possibleSpawns[randomInt].rotation) as GameObject;
            //NewWeapon.GetComponent<weaponSpawn>().mySpawnPoint = possibleSpawns[spawnIndex];

            possibleSpawns.RemoveAt(spawnIndex);
        }
            //InvokeRepeating("spawnRandom", startSpawning, spawnDelay);
    }

  
}
