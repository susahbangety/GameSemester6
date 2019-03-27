using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerWeapon : MonoBehaviour
{
    private Spawner sp;
    public Transform mySpawnPoint;

    public EquipWeapon eqw;

    void Start()
    {
        sp = GameObject.Find("WeaponSpawn").GetComponent<Spawner>();
        eqw = GameObject.FindGameObjectWithTag("Player").GetComponent<EquipWeapon>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (eqw.weaponActive == false && eqw.currWeapon == null)
            {
                //Destroy(gameObject);
                Debug.Log("You Pick Up " + gameObject);
                StartCoroutine(pickupWeapon(col.gameObject));
            }
        }
    }

    IEnumerator pickupWeapon(GameObject weap)
    {
        yield return new WaitForSeconds(0);

        for (int i = 0; i < sp.spawnPos.Length; i++)
        {
            if (sp.spawnPos[i] == mySpawnPoint)
            {
                sp.possibleSpawns.Add(sp.spawnPos[i]);
            }
        }
        Destroy(gameObject);
    }
}
