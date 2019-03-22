using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public bool weaponActive;

    public GameObject playerHand;
    public GameObject currWeapon;
    public GameObject Weapon1;
    public GameObject Weapon2;
   // public Rigidbody[] rgbWeapon;
    public Transform dropArea;
    //public GameObject Weapon3;
    //public GameObject throwDirection;

    //public Spawner spawn;
    public dropWeapon dropWeap;
    //public pickupItem pickUp;


    //public GameObject katana;
    //public GameObject katanaHand;

    void Start()
    {
        //Instantiate(katana, new Vector3(0,0,0),Quaternion.Euler(0,0,0),katanaHand.transform);
        weaponActive = false;
        currWeapon = playerHand;
        //currWeapon = playerHand;
        //playerHand.SetActive(false);
        Weapon1.SetActive(false);
        Weapon2.SetActive(false);
        //rgbWeapon = GetComponents<Rigidbody>();
        //Weapon3.SetActive(false);
    }

    void Update()
    {
        //pickUp.SendMessage("OnTriggerEnter");
        //gameObject.GetComponent<GameObject>();
        //pickUp = GameObject.Find("WeaponSpawn").GetComponent<pickupItem>();
        //throwWeapon();
        //dropWeap.droppingWeap();   
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Short" && weaponActive == false && currWeapon == playerHand)
        {
            Debug.Log("You Use " + collider.gameObject.name);
            Destroy(collider.gameObject);
            weaponActive = true;
            currWeapon = Weapon1;
            //currWeapon = playerHand;
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            //Weapon3.SetActive(false);
            //weaponActive = true;
            //Debug.Log("You Use " + collider.gameObject.name);
        }
        if (collider.gameObject.tag == "Medium" && weaponActive == false && currWeapon == playerHand)
        {
            Debug.Log("You Use " + collider.gameObject.name);
            Destroy(collider.gameObject);
            weaponActive = true;
            currWeapon = Weapon2;
            //currWeapon = playerHand;
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            //Weapon3.SetActive(false);
            //weaponActive = true;
            //Debug.Log("You Use " + collider.gameObject.name);
        }
        //if (collider.gameObject.tag == "Weapon 3" && weaponActive == false)
        //{
        //    playerHand = Weapon3;
        //    //currWeapon = playerHand;
        //    Weapon1.SetActive(false);
        //    Weapon2.SetActive(false);
        //    Weapon3.SetActive(true);
        //    weaponActive = true;
        //    Debug.Log("You Use " + collider.gameObject.tag);
        //}
    }

    //public void throwWeapon()
    //{
    //    for (int i = 0; i < rgbWeapon.Length; i++) {
    //        if (weaponActive == true && currWeapon == true)
    //        {
    //            if (Input.GetKeyDown(KeyCode.G)) /*(Input.GetKeyDown(im.TriangleButton[ControlNumber]))*/
    //            {
    //                //transform.Translate(Vector3.forward * Time.deltaTime);
    //                //Vector3 weaponPosition = transform.position;
    //                //weaponPosition.z = 0.1f;
    //                //transform.position = weaponPosition;
    //                //eq.playerHand.SetActive(false);
    //                rgbWeapon[i].AddForce(dropArea.forward * 100);
    //                StartCoroutine(weaponThrow());
    //                //gameObject.SetActive(false);
    //                weaponActive = false;
    //                Debug.Log("You Drop some " + currWeapon);
    //                //gameObject.SetActive(false);
    //                //StartCoroutine(weaponThrow());
    //                //eqw.currWeapon = eqw.playerHand;
    //                //StartCoroutine(weaponThrow());
    //                //Debug.Log("You Drop some "+eq.playerHand);
    //                //transform.Translate(Vector3.forward * Time.deltaTime);
    //            }
    //        }
    //    }
    //}

    //IEnumerator weaponThrow()
    //{
    //    yield return new WaitForSeconds(2);
    //    //GameObject newThrower = Instantiate(gameObject) as GameObject;
    //    for (int i=0; i<rgbWeapon.Length; i++)
    //    {
    //        rgbWeapon[i].velocity = new Vector3(0, 0, 0);
    //        pickUp.gameObject.transform.eulerAngles = pickUp.gameObject.transform.parent.transform.eulerAngles;
    //        pickUp.gameObject.transform.position = pickUp.gameObject.transform.parent.transform.position;
    //        //gameObject.transform.localScale = gameObject.transform.parent.transform.localScale;
    //        //newThrower.transform.localScale = gameObject.transform.parent.transform.localScale;
    //        //GameObject newThrower = Instantiate(gameObject) as GameObject;
    //        pickUp.gameObject.SetActive(false);
    //        currWeapon = playerHand;
    //    }
    //}

    //public void weaponUsed()
    //{
    //    GameObject Used = Instantiate(spawn as MonoBehaviour).gameObject;
    //    Used.SetActive(true);

    //    Used.transform.parent = playerHand.transform;
    //    Used.transform.position = playerHand.transform.position;
    //}


}
