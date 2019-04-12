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
    public GameObject weaponsArea;
    //public Transform dropArea;

    public PlayerMovement pm;
    public InputManager im;
    public EquipWeapon eqw;
    public PlayerAttack patt;
    public Animator _anim;
    //public dropWeapon drop;

    void Start()
    {
        //sp = GameObject.Find("WeaponSpawn").GetComponent<Spawner>();
        //eqw = GameObject.FindGameObjectWithTag("Player").GetComponent<EquipWeapon>();
        //drop = GameObject.Find("DropArea").GetComponent<dropWeapon>();
        //StartCoroutine(pickupWeapon());
        
        rgb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
            if(gameObject.name == "AxeEquip" && eqw.weaponActive == false)
            {
                transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
                throwWeapon();
            }
            if (gameObject.name == "SwordEquip" && eqw.weaponActive == false)
            {
                //transform.rotation = Quaternion.Euler(pm.transform.rotation.x, 90, pm.transform.rotation.z);
                transform.rotation = pm.transform.rotation;
                throwWeapon();
            }
            if (gameObject.name == "HammerEquip" && eqw.weaponActive == false)
            {
                transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
                throwWeapon();
            }
            if (gameObject.name == "SpearEquip" && eqw.weaponActive == false)
            {
                transform.rotation = pm.transform.rotation;
                throwWeapon();
            }
            if (gameObject.name == "KnifeEquip" && eqw.weaponActive == false)
            {
                transform.rotation = areaDrop.transform.rotation;
                throwWeapon();
            }
            else
            {
                throwWeapon();
            }
        
    }

    public void throwWeapon()
    {
        if (eqw.weaponActive == true && eqw.currWeapon == true && patt.AttackState == false)
        {
            if /*(Input.GetKeyDown(KeyCode.G))*/ (Input.GetKeyDown(im.TriangleButton[ControlNumber]))
            {
                gameObject.transform.parent = weaponsArea.transform;
                //_anim.GetComponent<Animator>().SetBool("Running", false);
                rgb.AddForce(eqw.dropArea.forward * 100);
                //transform.rotation = new Quaternion(areaDrop.rotation.x, areaDrop.rotation.y, areaDrop.rotation.z, 1);
                StartCoroutine(weaponThrow());
                eqw.weaponActive = false;
                Debug.Log("You Drop some " + eqw.currWeapon);
            }
        }
    }

    IEnumerator weaponThrow()
    {
        yield return new WaitForSeconds(2);
        if (eqw.currWeapon == eqw.Axe)
        {
            gameObject.transform.parent = eqw.handAxe.transform;
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
            eqw.currWeapon = null;
        }
        if (eqw.currWeapon == eqw.Sword)
        {
            gameObject.transform.parent = eqw.handSword.transform;
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
            eqw.currWeapon = null;
        }
        if (eqw.currWeapon == eqw.Spear)
        {
            gameObject.transform.SetParent(eqw.handSpear.transform);
            rgb.velocity = new Vector3(0, 0, 0);
            gameObject.transform.eulerAngles = gameObject.transform.parent.transform.eulerAngles;
            gameObject.transform.position = gameObject.transform.parent.transform.position;
            gameObject.transform.localScale = new Vector3(1,1,1);
            gameObject.SetActive(false);
            patt.HaveWeapon = false;
            patt.HaveWeaponAxe = false;
            patt.HaveWeaponKnife = false;
            patt.HaveWeaponSpear = false;
            patt.HaveWeaponSword = false;
            patt.HaveWeaponHammer = false;
            eqw.currWeapon = null;
        }
        if (eqw.currWeapon == eqw.Knife)
        {
            gameObject.transform.SetParent(eqw.handKnife.transform);
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
            eqw.currWeapon = null;
        }
        if (eqw.currWeapon == eqw.Hammer)
        {
            gameObject.transform.SetParent(eqw.handHammer.transform);
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
            eqw.currWeapon = null;
        }
    }

    //IEnumerator pickupWeapon(GameObject weap)
    //{
    //    yield return new WaitForSeconds(0);

    //    for (int i = 0; i < sp.spawnPos.Length; i++)
    //    {
    //        if (sp.spawnPos[i] == mySpawnPoint)
    //        {
    //            sp.possibleSpawns.Add(sp.spawnPos[i]);
    //        }
    //    }
    //    Destroy(gameObject);
    //}
}
