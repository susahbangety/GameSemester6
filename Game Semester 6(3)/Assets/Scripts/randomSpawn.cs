using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnTime = 1.5f;
    public GameObject[] Weapon;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWeapon", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnWeapon()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        int weaponIndex = Random.Range(0, Weapon.Length);

        Instantiate(Weapon[weaponIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }
}
