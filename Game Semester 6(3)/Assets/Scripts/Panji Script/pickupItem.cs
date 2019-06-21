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
        if (/*gameObject.name == "SpearEquip" &&*/ gameObject.transform.parent == null)
        {
            //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            Vector3 direction = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
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
            Debug.Log("You Drop some " + gameObject.name);
            patt.isThrowing = false;
            gameObject.transform.parent = null;
            rgb.AddForce(eqw.dropArea.forward * 100);
            StartCoroutine(weaponThrow());
            eqw.weaponActive = false;
        }
        if (patt.isThrowingKnife == true)
        {
            Debug.Log("You Drop some " + gameObject.name);
            patt.isThrowingKnife = false;
            gameObject.transform.parent = null;
            rgb.AddForce(eqw.dropArea.forward * 100);
            StartCoroutine(weaponThrow());
            eqw.weaponActive = false;
        }

    }

    public void throwWeapon()
    {
        if (eqw.weaponActive == true && patt.AttackState == false)
        {
            if /*(Input.GetKeyDown(KeyCode.G))*/ (Input.GetKeyDown(im.TriangleButton[ControlNumber]))
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
        yield return new WaitForSeconds(2);
        if (gameObject.tag == "WeaponPlayer1")
        {
            if (gameObject.name == "AxeEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandAxe1").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.SetActive(false);
                //eqw.weaponActive = false;
                patt.HaveWeapon = false;
                patt.HaveWeaponAxe = false;
                //_anim.enabled = false;
            }
            if (gameObject.name == "SwordEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandSword1").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.SetActive(false);
                //eqw.weaponActive = false;
                patt.HaveWeapon = false;
                patt.HaveWeaponSword = false;
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
                //eqw.weaponActive = false;
                patt.HaveWeapon = false;
                patt.HaveWeaponSpear = false;
            }
            if (gameObject.name == "KnifeEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandKnife1").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                gameObject.SetActive(false);
                //eqw.weaponActive = false;
                patt.HaveWeapon = false;
                patt.HaveWeaponKnife = false;
            }
            if (gameObject.name == "HammerEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandHammer1").transform;
                rgb.velocity = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
                gameObject.transform.position = gameObject.transform.parent.transform.position;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                gameObject.SetActive(false);
                //eqw.weaponActive = false;
                patt.HaveWeapon = false;
                patt.HaveWeaponHammer = false;
            }
        }
        else if (gameObject.tag == "WeaponPlayer2")
        {
            if (gameObject.name == "AxeEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandAxe2").transform;
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
            if (gameObject.name == "SwordEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandSword2").transform;
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
            if (gameObject.name == "SpearEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandSpear2").transform;
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
            if (gameObject.name == "KnifeEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandKnife2").transform;
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
            if (gameObject.name == "HammerEquip")
            {
                //eqw.currWeapon = null;
                gameObject.transform.parent = GameObject.Find("HandHammer2").transform;
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
}
