using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerWeapon : MonoBehaviour
{
    private Spawner sp;
    public Transform mySpawnPoint;
    //public float rotate;

    public float degreesPerSecond;
    public float amplitude;
    public float frequency;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public GameObject Player1;
    public GameObject Player2;

    public EquipWeapon Equip1;
    public EquipWeapon Equip2;

    public PlayerAttack Patk1;
    public PlayerAttack Patk2;
    //public bool Equipable = true;

    //public ParticleSystem WeaponSpawnEffect;


    void Start()
    {
        //WeaponSpawnEffect.Stop();

        // Store the starting position & rotation of the object
        posOffset = transform.position;

        Player1 = GameObject.FindGameObjectWithTag("Player");
        Equip1 = Player1.GetComponent<EquipWeapon>();
        Patk1 = Player1.GetComponent<PlayerAttack>();

        Player2 = GameObject.FindGameObjectWithTag("Player2");
        Equip2 = Player2.GetComponent<EquipWeapon>();
        Patk2 = Player2.GetComponent<PlayerAttack>();

        sp = GameObject.Find("WeaponSpawn").GetComponent<Spawner>();
        if (gameObject.tag == "HammerDrop")
        {
            transform.rotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
        if (gameObject.tag == "AxeDrop")
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -180);
        }
        if (gameObject.tag == "KnifeDrop")
        {
            transform.rotation = Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z);
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
        if (gameObject.tag == "SpearDrop")
        {
            transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        }
        if (gameObject.tag == "SwordDrop")
        {
            transform.position = new Vector3(transform.position.x, 2.6f, transform.position.z);
        }
    }

    void Update()
    {

        //if (gameObject.tag == "HammerDrop" || gameObject.tag == "KnifeDrop")
        //{
        //    gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * rotate);
        //}
        //else
        //{
        //    gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotate);
        //}

        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            StartCoroutine(pickupWeapon(col.gameObject));
            Debug.Log("You Pick Up " + gameObject);
        }
        //else if (col.gameObject.tag == "Player2" /*&& Equip2.weaponActive == false && Patk2.HaveWeapon == false)
        //{
        //    Debug.Log("You Pick Up " + gameObject);
        //    StartCoroutine(pickupWeapon());
        //}
    }

    IEnumerator pickupWeapon(GameObject weap)
    {
        yield return new WaitForSeconds(0);

        for (int i = 0; i < sp.spawnPos.Length; i++)
        {
            if (sp.spawnPos[i] == mySpawnPoint)
            {
                sp.possibleSpawns.Add(sp.spawnPos[i]);
                //WeaponSpawnEffect.Play();
            }
        }
        Destroy(gameObject);
    }
}
