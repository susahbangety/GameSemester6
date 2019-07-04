using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{

    public int PlayerKeberapa;
    public CharacterAttributes ca;

    public bool weaponActive;

    public GameObject playerHandRight;
    public GameObject playerHandLeft;

    [Header("EQUIP AXE")]
    public GameObject Axe;
    //public GameObject handAxe;

    [Header("EQUIP SWORD")]
    public GameObject Sword;
    //public GameObject handSword;

    [Header("EQUIP SPEAR")]
    public GameObject Spear;
    //public GameObject handSpear;

    [Header("EQUIP HAMMER")]
    public GameObject Hammer;
    //public GameObject handHammer;

    [Header("EQUIP KNIFE")]
    public GameObject Knife;
    //public GameObject handKnife;
    private Rigidbody rgbWeapon;
    public Transform dropArea;
    //private ParticleSystem particle;
    //public GameObject Weapon3;
    //public GameObject throwDirection;
    //public Spawner spawn;
    public PlayerAttack patt;
    private pickupItem pickUp;

    public AudioSource PickUpSound;




    //public GameObject katana;
    //public GameObject katanaHand;

    void Start()
    {
        //Instantiate(katana, new Vector3(0,0,0),Quaternion.Euler(0,0,0),katanaHand.transform);
        //particle = GetComponent<ParticleSystem>();
        rgbWeapon = GetComponent<Rigidbody>();
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

    public void OnTriggerEnter(Collider collider)
    {
        if (PlayerKeberapa == 1)
        {
            if (/*collider.gameObject.tag == "WeaponDrop" && */weaponActive == false && patt.HaveWeapon == false)
            {
                if (collider.gameObject.tag == "AxeDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //Destroy(collider.gameObject);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Axe.GetComponent<ParticleSystem>().Stop();
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponAxe = true;
                    Axe.SetActive(true);
                    PickUpSound.Play();
                    //buat ngedamage
                    ca.amountDamage[0] = Axe.GetComponent<WeaponDamage>().DamageSenjata;

                }
                else if (collider.gameObject.tag == "SwordDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponSword = true;
                    Sword.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[0] = Sword.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "SpearDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponSpear = true;
                    Spear.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[0] = Spear.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "KnifeDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponKnife = true;
                    Knife.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[0] = Knife.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "HammerDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponHammer = true;
                    Hammer.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[0] = Hammer.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else {
                    ca.amountDamage[0] = 5;
                }
            }
        }
        else if (PlayerKeberapa == 2)
        {
            if (/*collider.gameObject.tag == "WeaponDrop" && */weaponActive == false && patt.HaveWeapon == false)
            {
                if (collider.gameObject.tag == "AxeDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //Destroy(collider.gameObject);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Axe.GetComponent<ParticleSystem>().Stop();
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponAxe = true;
                    Axe.SetActive(true);
                    PickUpSound.Play();
                    //buat ngedamage
                    ca.amountDamage[1] = Axe.GetComponent<WeaponDamage>().DamageSenjata;

                }
                else if (collider.gameObject.tag == "SwordDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponSword = true;
                    Sword.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[1] = Sword.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "SpearDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponSpear = true;
                    Spear.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[1] = Spear.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "KnifeDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponKnife = true;
                    Knife.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[1] = Knife.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "HammerDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponHammer = true;
                    Hammer.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[1] = Hammer.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else
                {
                    ca.amountDamage[1] = 5;
                }
            }
        }
        else if (PlayerKeberapa == 3)
        {
            if (/*collider.gameObject.tag == "WeaponDrop" && */weaponActive == false && patt.HaveWeapon == false)
            {
                if (collider.gameObject.tag == "AxeDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //Destroy(collider.gameObject);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Axe.GetComponent<ParticleSystem>().Stop();
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponAxe = true;
                    Axe.SetActive(true);
                    PickUpSound.Play();
                    //buat ngedamage
                    ca.amountDamage[2] = Axe.GetComponent<WeaponDamage>().DamageSenjata;

                }
                else if (collider.gameObject.tag == "SwordDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponSword = true;
                    Sword.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[2] = Sword.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "SpearDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponSpear = true;
                    Spear.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[2] = Spear.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "KnifeDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponKnife = true;
                    Knife.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[2] = Knife.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "HammerDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponHammer = true;
                    Hammer.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[2] = Hammer.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else
                {
                    ca.amountDamage[2] = 5;
                }
            }
        }
        else if (PlayerKeberapa == 4) {
            if (/*collider.gameObject.tag == "WeaponDrop" && */weaponActive == false && patt.HaveWeapon == false)
            {
                if (collider.gameObject.tag == "AxeDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //Destroy(collider.gameObject);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Axe.GetComponent<ParticleSystem>().Stop();
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponAxe = true;
                    Axe.SetActive(true);
                    PickUpSound.Play();
                    //buat ngedamage
                    ca.amountDamage[3] = Axe.GetComponent<WeaponDamage>().DamageSenjata;

                }
                else if (collider.gameObject.tag == "SwordDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponSword = true;
                    Sword.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[3] = Sword.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "SpearDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponSpear = true;
                    Spear.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[3] = Spear.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "KnifeDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponKnife = true;
                    Knife.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[3] = Knife.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else if (collider.gameObject.tag == "HammerDrop")
                {
                    Debug.Log("You Use " + collider.gameObject.name);
                    //rgbWeapon.constraints = RigidbodyConstraints.FreezePositionY;
                    //Destroy(collider.gameObject);
                    weaponActive = true;
                    patt.HaveWeapon = true;
                    patt.HaveWeaponHammer = true;
                    Hammer.SetActive(true);
                    PickUpSound.Play();
                    ca.amountDamage[3] = Hammer.GetComponent<WeaponDamage>().DamageSenjata;
                }
                else
                {
                    ca.amountDamage[3] = 5;
                }
            }
        }
    }
}
