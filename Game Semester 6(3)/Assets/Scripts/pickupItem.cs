using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupItem : MonoBehaviour
{
    //public float destroyTime = 0.5f;
    private Spawner sp;
    public Transform mySpawnPoint;
    public Rigidbody rgb;
    public int ControlNumber;
    //public Transform dropArea;

    public InputManager im;
    public EquipWeapon eqw;
    //public dropWeapon drop;

    void Start()
    {
        sp = GameObject.Find("WeaponSpawn").GetComponent<Spawner>();
        eqw = GameObject.FindGameObjectWithTag("Player").GetComponent<EquipWeapon>();
        //drop = GameObject.Find("DropArea").GetComponent<dropWeapon>();
        //StartCoroutine(pickupWeapon());
        rgb = GetComponent<Rigidbody>();
        //gameObject.transform.parent = gameObject.transform;
    }

    void Update()
    {
        //transform.Translate(1,1,0);
        throwWeapon();
        //StartCoroutine(weaponThrow());
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" )
        {
            if (eqw.weaponActive == false && eqw.currWeapon == eqw.playerHand)
            {
                //Destroy(gameObject);
                Debug.Log("You Pick Up " + gameObject);
                StartCoroutine(pickupWeapon(col.gameObject));
            }
        }
    }

    public void throwWeapon()
    {
        if (eqw.weaponActive == true && eqw.currWeapon == true)
        {
            if (Input.GetKeyDown(KeyCode.G)) /*(Input.GetKeyDown(im.TriangleButton[ControlNumber]))*/
            {
                //transform.Translate(Vector3.forward * Time.deltaTime);
                //Vector3 weaponPosition = transform.position;
                //weaponPosition.z = 0.1f;
                //transform.position = weaponPosition;
                //eq.playerHand.SetActive(false);
                rgb.AddForce(eqw.dropArea.forward * 100);
                StartCoroutine(weaponThrow());
                //gameObject.SetActive(false);
                eqw.weaponActive = false;
                Debug.Log("You Drop some " + eqw.currWeapon);
                //gameObject.SetActive(false);
                //StartCoroutine(weaponThrow());
                //eqw.currWeapon = eqw.playerHand;
                //StartCoroutine(weaponThrow());
                //Debug.Log("You Drop some "+eq.playerHand);
                //transform.Translate(Vector3.forward * Time.deltaTime);
            }
        }
    }

    IEnumerator weaponThrow()
    {
        yield return new WaitForSeconds(2);
        //GameObject newThrower = Instantiate(gameObject) as GameObject;
        rgb.velocity = new Vector3(0, 0, 0);
        gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
        gameObject.transform.position = gameObject.transform.parent.transform.position;
        //gameObject.transform.localScale = gameObject.transform.parent.transform.localScale;
        //newThrower.transform.localScale = gameObject.transform.parent.transform.localScale;
        //GameObject newThrower = Instantiate(gameObject) as GameObject;
        gameObject.SetActive(false);
        eqw.currWeapon = eqw.playerHand;
    }


    //public void throwWeapon()
    //{
    //    if (eqw.weaponActive == true && eqw.playerHand == true)
    //    {
    //        if (Input.GetKeyDown(KeyCode.G))
    //        {

    //            rgb.AddForce(1, 0, 1);
    //            //transform.Translate(Vector3.forward * Time.deltaTime);

    //            //eq.playerHand.SetActive(false);
    //            eqw.weaponActive = false;
    //            Debug.Log("You Drop some " + eqw.playerHand);
    //            eqw.playerHand = null;
    //            //Debug.Log("You Drop some "+eq.playerHand);
    //        }
    //    }
    //}

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
