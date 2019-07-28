using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupItem : MonoBehaviour
{
    public float ThrowSpeed;
    public Rigidbody rgb;
    public int ControlNumber;
    public float rotateSpeed;
    public Transform areaDrop;
    public GameObject player;

    public PlayerMovement pm;
    public InputManager im;
    public EquipWeapon eqw;
    public PlayerAttack patt;
    private Animation _anim;
    public CharacterAttributes CA;
    public BoxCollider ColliderWeapon;

    void Start()
    {
        ColliderWeapon = GetComponent<BoxCollider>();
        rgb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animation>();
  
    }

    void Update()
    {
       
        if (gameObject.transform.parent == null)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
        throwWeapon();


        if (patt.isThrowing == true)
        {
            Debug.Log("You Drop some " + gameObject.name);
            patt.isThrowing = false;
            gameObject.transform.parent = null;
            rgb.AddForce(eqw.dropArea.forward * ThrowSpeed);
            eqw.weaponActive = false;
            patt.HaveWeapon = false;
            patt.HaveWeaponAxe = false;
            patt.HaveWeaponSpear = false;
            patt.HaveWeaponSword = false;
            patt.HaveWeaponHammer = false;
            StartCoroutine(weaponThrow());
        }
        if (patt.isThrowingKnife == true)
        {
            Debug.Log("You Drop some " + gameObject.name);
            patt.isThrowingKnife = false;
            gameObject.transform.parent = null;
            rgb.AddForce(eqw.dropArea.forward * ThrowSpeed);
            eqw.weaponActive = false;
            patt.HaveWeapon = false;
            patt.HaveWeaponKnife = false;
            StartCoroutine(weaponThrow());
        }
        if (patt.isUltiSpear == true)
        {
            Debug.Log("You Ulti " + gameObject.name);
            patt.isUltiSpear = false;
            gameObject.transform.parent = null;
            rgb.AddForce(eqw.dropArea.forward * 300);
            eqw.weaponActive = false;
            patt.HaveWeapon = false;
            patt.HaveWeaponSpear = false;
            StartCoroutine(weaponThrow());
        }
    }

    public void throwWeapon()
    {
        if (eqw.weaponActive == true && patt.AttackState == false && patt.HaveWeapon == true && Input.GetKeyDown(im.YButton[ControlNumber]))
        {
            if(Input.GetKeyDown(im.YButton[ControlNumber]))
            {
                if (gameObject.name == "KnifeEquip")
                {
                    player.GetComponent<Animator>().SetTrigger("ThrowKnife");
                }
                else
                {
                    player.GetComponent<Animator>().SetTrigger("Throw");
                }
            }
        }
    }

    IEnumerator weaponThrow()
    {
        ColliderWeapon.enabled = true;
        yield return new WaitForSeconds(3);
        ColliderWeapon.enabled = false;
        if (gameObject.tag == "WeaponPlayer1")
        {
            if (gameObject.name == "AxeEquip")
            {
                gameObject.transform.parent = GameObject.Find("HandAxe1").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.SetActive(false);
                //patt.HaveWeaponAxe = false;
  
            }
            if (gameObject.name == "SwordEquip")
            {
                gameObject.transform.parent = GameObject.Find("HandSword1").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.SetActive(false);
                //patt.HaveWeaponSword = false;
            }
            if (gameObject.name == "SpearEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandSpear1").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                gameObject.SetActive(false);
                //patt.HaveWeaponSpear = false;
            }
            if (gameObject.name == "KnifeEquip")
            {
                gameObject.transform.parent = GameObject.Find("HandKnife1").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                gameObject.SetActive(false);
                //patt.HaveWeaponKnife = false;
            }
            if (gameObject.name == "HammerEquip")
            {
                gameObject.transform.parent = GameObject.Find("HandHammer1").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                gameObject.SetActive(false);
                //patt.HaveWeaponHammer = false;
            }
        }
        else if (gameObject.tag == "WeaponPlayer2")
        {
            if (gameObject.name == "AxeEquip")
            {
                gameObject.transform.parent = GameObject.Find("HandAxe2").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.SetActive(false);
                //patt.HaveWeaponAxe = false;
            }
            if (gameObject.name == "SwordEquip")
            {
                gameObject.transform.parent = GameObject.Find("HandSword2").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.SetActive(false);
                //patt.HaveWeaponSword = false;

            }
            if (gameObject.name == "SpearEquip")
            {
                gameObject.transform.parent = GameObject.Find("HandSpear2").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.SetActive(false);
                //patt.HaveWeaponSpear = false;
            }
            if (gameObject.name == "KnifeEquip")
            {
                gameObject.transform.parent = GameObject.Find("HandKnife2").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.SetActive(false);
                //patt.HaveWeaponKnife = false;
            }
            if (gameObject.name == "HammerEquip")
            {
                gameObject.transform.parent = GameObject.Find("HandHammer2").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.SetActive(false);
                //patt.HaveWeaponHammer = false;
            }
        }

    }
}
