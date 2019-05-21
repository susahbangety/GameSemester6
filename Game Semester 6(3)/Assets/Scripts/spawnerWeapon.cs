using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerWeapon : MonoBehaviour
{
    private Spawner sp;
    public Transform mySpawnPoint;
    public float rotate;

    public EquipWeapon eqw;

    void Start()
    {
        sp = GameObject.Find("WeaponSpawn").GetComponent<Spawner>();
        eqw = GameObject.FindGameObjectWithTag("Player").GetComponent<EquipWeapon>();
        if (gameObject.tag == "Hammer")
        {
            transform.rotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
        if (gameObject.tag == "Axe")
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -180);
        }
        if (gameObject.tag == "Knife")
        {
            transform.rotation = Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z);
            transform.position = new Vector3(transform.position.x, 1.7f, transform.position.z);
        }
        if (gameObject.tag == "Spear")
        {
            transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        }
        if (gameObject.tag == "Sword")
        {
            transform.position = new Vector3(transform.position.x, 2.6f, transform.position.z);
        }
    }

    void Update()
    {
        if (gameObject.tag == "Hammer" || gameObject.tag == "Knife")
        {
            gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * rotate);
        }
        else
        {
            gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotate);
        }


        //if (gameObject.tag == "Sword")
        //{
        //    transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
        //}

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (eqw.weaponActive == false)
            {
                //Destroy(gameObject);
                Debug.Log("You Pick Up " + gameObject);
                StartCoroutine(pickupWeapon(col.gameObject));
            }
        }
        else if (col.gameObject.tag == "Player2")
        {
            if (eqw.weaponActive == false)
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
