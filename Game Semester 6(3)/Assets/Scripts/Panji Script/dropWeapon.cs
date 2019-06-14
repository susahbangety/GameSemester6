//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class dropWeapon : MonoBehaviour
//{
//    public Transform dropArea;
//    public float speed;
//    public int ControlNumber;

//    //public PlayerHealth ph;
//    public EquipWeapon eq;
//    //public pickupItem pick;
//    public InputManager im;

//    [Header("Katana")]
//    public Rigidbody katanargb;
//    public GameObject katanaHand;
//    public GameObject katana;


//    void Start()
//    {
//        //pick = GameObject.FindGameObjectWithTag("Short").GetComponent<pickupItem>();
//        //pick = GameObject.FindGameObjectWithTag("Medium").GetComponent<pickupItem>();
//        //pick = GameObject.Find("Weapon Green").GetComponent<pickupItem>();
//        //rgb = GetComponent<Rigidbody>();
//    }

//    void Update()
//    {
//        //throwWeapon();
//    }

//    public void droppingWeap()
//    {
//        if (ph.CurrHealth <= 0)
//        {
//            if (eq.currWeapon == true && eq.weaponActive == true)
//            {
//                //Instantiate(eq.playerHand, dropArea.transform.position, dropArea.transform.rotation);
//                //Destroy(gameObject);
//                eq.currWeapon.SetActive(false);
//                eq.weaponActive = false;
//                Debug.Log("You Died and Drop " + eq.currWeapon);
//                eq.currWeapon = null;
//                //Destroy(eq.playerHand);
//                //Debug.Log("You Drop A " +eq.playerHand);
//            }
//        }
//    }

//    //public void throwWeapon()
//    //{
//    //    if (eq.weaponActive == true && eq.playerHand == true)
//    //    {
//    //        if (Input.GetKeyDown(im.TriangleButton[ControlNumber]))
//    //        {
//    //            Rigidbody rbody = Instantiate(rgb, dropArea.position, dropArea.rotation) as Rigidbody;
//    //            rbody.AddForce(dropArea.forward * 1000);
//    //            katanargb.AddForce(dropArea.forward * 1000);
//    //            StartCoroutine(throwDestroy());
//    //            transform.Translate(Vector3.forward * Time.deltaTime);
//    //            Destroy(eq.playerHand);
//    //            eq.playerHand.SetActive(false);
//    //            eq.weaponActive = false;
//    //            Debug.Log("You Drop some " + eq.playerHand);
//    //            eq.playerHand = null;
//    //            eq.Weapon1.SetActive(false);
//    //            eq.Weapon2.SetActive(false);
//    //            Destroy(eq.playerHand);
//    //            Debug.Log("You Drop some " + eq.playerHand);
//    //        }
//    //    }
//    //}

//    //IEnumerator throwDestroy()
//    //{
//    //    yield return new WaitForSeconds(1f);
//    //    katanargb.velocity = new Vector3(0, 0, 0);
//    //    katana.transform.eulerAngles = new Vector3(0,0,0);
//    //    katana.transform.position = new Vector3(0, 0, 0);
//    //    katana.transform.localScale = new Vector3(1, 1, 1);
//    //}
//}
