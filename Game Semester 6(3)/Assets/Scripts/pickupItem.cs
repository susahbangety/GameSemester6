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
    //public Transform dropArea;

    public PlayerMovement pm;
    public InputManager im;
    public EquipWeapon eqw;
    public PlayerAttack patt;
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
        
        throwWeapon();
        
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Player" )
    //    {
    //        if (eqw.weaponActive == false && eqw.currWeapon == eqw.playerHand)
    //        {
    //            //Destroy(gameObject);
    //            Debug.Log("You Pick Up " + gameObject);
    //            StartCoroutine(pickupWeapon(col.gameObject));
    //        }
    //    }
    //}

    public void throwWeapon()
    {
        if (eqw.weaponActive == true && eqw.currWeapon == true && patt.AttackState == false)
        {
            if /*(Input.GetKeyDown(KeyCode.G))*/ (Input.GetKeyDown(im.TriangleButton[ControlNumber]))
            {
                
                rgb.AddForce(eqw.dropArea.forward * 100);
                StartCoroutine(weaponThrow());
                
                eqw.weaponActive = false;
                Debug.Log("You Drop some " + eqw.currWeapon);
               
            }
        }
    }

    IEnumerator weaponThrow()
    {
        yield return new WaitForSeconds(2);
        
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
