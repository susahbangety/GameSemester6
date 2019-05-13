using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupItem : MonoBehaviour
{
    //public float destroyTime = 0.5f;
    //private Spawner sp;
    //public Transform mySpawnPoint;
    public Rigidbody rgb;
    public int ControlNumber;
    public float rotateSpeed;
    public Transform areaDrop;
    public GameObject player;
    //public Transform dropArea;

    public PlayerMovement pm;
    public InputManager im;
    public EquipWeapon eqw;
    public PlayerAttack patt;
    private Animation _anim;
    public CharacterAttributes CA;

    //public dropWeapon drop;

    void Start()
    {
        //sp = GameObject.Find("WeaponSpawn").GetComponent<Spawner>();
        //eqw = GameObject.FindGameObjectWithTag("Player").GetComponent<EquipWeapon>();
        //drop = GameObject.Find("DropArea").GetComponent<dropWeapon>();
        //StartCoroutine(pickupWeapon());
        
        rgb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animation>();
    }

    void Update()
    {
        //if (gameObject.name == "AxeEquip" && eqw.weaponActive == false)
        //{
        //    //transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
        //    transform.rotation = pm.transform.rotation;
        //    //_anim.enabled = true;
        //    throwWeapon();
        //}
        //if (gameObject.name == "SwordEquip" && eqw.weaponActive == false)
        //{
        //    //transform.rotation = Quaternion.Euler(pm.transform.rotation.x, 90, pm.transform.rotation.z);
        //    transform.rotation = pm.transform.rotation;
        //    throwWeapon();
        //}
        //if (gameObject.name == "HammerEquip" && eqw.weaponActive == false)
        //{
        //    transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
        //    throwWeapon();
        //}
        //if (gameObject.name == "SpearEquip" && eqw.weaponActive == false)
        //{
        //    transform.rotation = pm.transform.rotation;
        //    throwWeapon();
        //}
        //if (gameObject.name == "KnifeEquip" && eqw.weaponActive == false)
        //{
        //    transform.rotation = areaDrop.transform.rotation;
        //    throwWeapon();
        //}
        //else
        //{
        throwWeapon();
            //}

        if (patt.isThrowing == true)
        {
            patt.isThrowing = false;
            gameObject.transform.parent = null;
            rgb.AddForce(eqw.dropArea.forward * 100);
            StartCoroutine(weaponThrow());
            eqw.weaponActive = false;

            Debug.Log("You Drop some " + eqw.currWeapon);
        }
        if (patt.isThrowingKnife == true)
        {
            patt.isThrowingKnife = false;
            gameObject.transform.parent = null;
            rgb.AddForce(eqw.dropArea.forward * 100);
            StartCoroutine(weaponThrow());
            eqw.weaponActive = false;

            Debug.Log("You Drop some " + eqw.currWeapon);
        }

    }

    public void throwWeapon()
    {
        if (eqw.weaponActive == true && eqw.currWeapon == true && patt.AttackState == false)
        {
            if /*(Input.GetKeyDown(KeyCode.G))*/ (Input.GetKeyDown(im.TriangleButton[ControlNumber]))
            {
                if (eqw.currWeapon == eqw.Knife)
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
        yield return new WaitForSeconds(2);
        if (eqw.currWeapon == eqw.Axe)
        {
            eqw.currWeapon = null;
            gameObject.transform.parent = GameObject.Find("HandAxe").transform;
            rgb.velocity = new Vector3(0, 0, 0);
            gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
            gameObject.transform.position = gameObject.transform.parent.transform.position;
            gameObject.SetActive(false);
            patt.HaveWeapon = false;
            patt.HaveWeaponAxe = false;
            patt.HaveWeaponKnife = false;
            patt.HaveWeaponSpear = false;
            patt.HaveWeaponSword = false;
            patt.HaveWeaponHammer = false;
            //_anim.enabled = false;
        }
        if (eqw.currWeapon == eqw.Sword)
        {
            eqw.currWeapon = null;
            gameObject.transform.parent = GameObject.Find("HandSword").transform;
            rgb.velocity = new Vector3(0, 0, 0);
            gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
            gameObject.transform.position = gameObject.transform.parent.transform.position;
            gameObject.SetActive(false);
            patt.HaveWeapon = false;
            patt.HaveWeaponAxe = false;
            patt.HaveWeaponKnife = false;
            patt.HaveWeaponSpear = false;
            patt.HaveWeaponSword = false;
            patt.HaveWeaponHammer = false;
        }
        if (eqw.currWeapon == eqw.Spear)
        {
            eqw.currWeapon = null;
            gameObject.transform.parent = GameObject.Find("HandSpear").transform;
            rgb.velocity = new Vector3(0, 0, 0);
            gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
            gameObject.transform.position = gameObject.transform.parent.transform.position;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
            patt.HaveWeapon = false;
            patt.HaveWeaponAxe = false;
            patt.HaveWeaponKnife = false;
            patt.HaveWeaponSpear = false;
            patt.HaveWeaponSword = false;
            patt.HaveWeaponHammer = false;
        }
        if (eqw.currWeapon == eqw.Knife)
        {
            eqw.currWeapon = null;
            gameObject.transform.parent = GameObject.Find("HandKnife").transform;
            rgb.velocity = new Vector3(0, 0, 0);
            gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
            gameObject.transform.position = gameObject.transform.parent.transform.position;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
            patt.HaveWeapon = false;
            patt.HaveWeaponAxe = false;
            patt.HaveWeaponKnife = false;
            patt.HaveWeaponSpear = false;
            patt.HaveWeaponSword = false;
            patt.HaveWeaponHammer = false;
        }
        if (eqw.currWeapon == eqw.Hammer)
        {
            eqw.currWeapon = null;
            gameObject.transform.parent = GameObject.Find("HandHammer").transform;
            rgb.velocity = new Vector3(0, 0, 0);
            gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
            gameObject.transform.position = gameObject.transform.parent.transform.position;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
            patt.HaveWeapon = false;
            patt.HaveWeaponAxe = false;
            patt.HaveWeaponKnife = false;
            patt.HaveWeaponSpear = false;
            patt.HaveWeaponSword = false;
            patt.HaveWeaponHammer = false;
        }

    }
}
