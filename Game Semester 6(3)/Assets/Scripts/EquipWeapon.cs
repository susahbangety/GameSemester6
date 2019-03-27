using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public bool weaponActive;

    public GameObject playerHandRight;
    public GameObject playerHandLeft;
    public GameObject currWeapon;
    public GameObject Axe;
    public GameObject Sword;
    public GameObject Spear;
    public GameObject Hammer;
    public GameObject Knife;
    // public Rigidbody[] rgbWeapon;
    public Transform dropArea;
    //public GameObject Weapon3;
    //public GameObject throwDirection;
    //public Spawner spawn;
    public PlayerAttack patt;
    public dropWeapon dropWeap;
    //public pickupItem pickUp;


    //public GameObject katana;
    //public GameObject katanaHand;

    void Start()
    {
        //Instantiate(katana, new Vector3(0,0,0),Quaternion.Euler(0,0,0),katanaHand.transform);
        weaponActive = false;
        Axe.SetActive(false);
        Sword.SetActive(false);
        Spear.SetActive(false);
        Knife.SetActive(false);
        Hammer.SetActive(false);
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
        if (collider.gameObject.tag == "Axe" && weaponActive == false && currWeapon == null)
        {
            Debug.Log("You Use " + collider.gameObject.name);
            //Destroy(collider.gameObject);
            weaponActive = true;
            currWeapon = Axe;
            patt.HaveWeapon = true;
            patt.HaveWeaponAxe = true;
            //patt.HaveWeaponKnife = false;
            //patt.HaveWeaponSpear = false;
            //patt.HaveWeaponSword = false;
            //patt.HaveWeaponHammer = false;
            Axe.SetActive(true);
            Spear.SetActive(false);
            Sword.SetActive(false);
            Knife.SetActive(false);
            Hammer.SetActive(false);
        }
        if (collider.gameObject.tag == "Sword" && weaponActive == false && currWeapon == null)
        {
            Debug.Log("You Use " + collider.gameObject.name);
            //Destroy(collider.gameObject);
            weaponActive = true;
            currWeapon = Sword;
            patt.HaveWeapon = true;
            //patt.HaveWeaponAxe = false;
            //patt.HaveWeaponKnife = false;
            //patt.HaveWeaponSpear = false;
            patt.HaveWeaponSword = true;
            //patt.HaveWeaponHammer = false;
            Axe.SetActive(false);
            Sword.SetActive(true);
            Spear.SetActive(false);
            Knife.SetActive(false);
            Hammer.SetActive(false);
        }
        if (collider.gameObject.tag == "Spear" && weaponActive == false && currWeapon == null)
        {
            Debug.Log("You Use " + collider.gameObject.name);
            //Destroy(collider.gameObject);
            weaponActive = true;
            currWeapon = Spear;
            patt.HaveWeapon = true;
            //patt.HaveWeaponAxe = false;
            //patt.HaveWeaponKnife = false;
            patt.HaveWeaponSpear = true;
            //patt.HaveWeaponSword = false;
            //patt.HaveWeaponHammer = false;
            Axe.SetActive(false);
            Sword.SetActive(false);
            Spear.SetActive(true);
            Knife.SetActive(false);
            Hammer.SetActive(false);
        }
        if (collider.gameObject.tag == "Knife" && weaponActive == false && currWeapon == null)
        {
            Debug.Log("You Use " + collider.gameObject.name);
            //Destroy(collider.gameObject);
            weaponActive = true;
            currWeapon = Knife;
            patt.HaveWeapon = true;
            //patt.HaveWeaponAxe = false;
            patt.HaveWeaponKnife = true;
            //patt.HaveWeaponSpear = false;
            //patt.HaveWeaponSword = false;
            //patt.HaveWeaponHammer = false;
            Axe.SetActive(false);
            Sword.SetActive(false);
            Spear.SetActive(false);
            Knife.SetActive(true);
            Hammer.SetActive(false);
        }
        if (collider.gameObject.tag == "Hammer" && weaponActive == false && currWeapon == null)
        {
            Debug.Log("You Use " + collider.gameObject.name);
            //Destroy(collider.gameObject);
            weaponActive = true;
            currWeapon = Hammer;
            patt.HaveWeapon = true;
            //patt.HaveWeaponAxe = false;
            //patt.HaveWeaponKnife = false;
            //patt.HaveWeaponSpear = false;
            //patt.HaveWeaponSword = false;
            patt.HaveWeaponHammer = true;
            Axe.SetActive(false);
            Sword.SetActive(false);
            Spear.SetActive(false);
            Knife.SetActive(false);
            Hammer.SetActive(true);
        }
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
