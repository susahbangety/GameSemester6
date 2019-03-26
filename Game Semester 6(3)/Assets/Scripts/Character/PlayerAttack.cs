using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("Buat Inputan")]
    public InputManager IM;
    public int ControlNumber;

    [Header("Senjatanya")]
    public GameObject Senjata;

    [Header("DIISI TAG DAMAGECOLLIDER TAG")]
    public string DamageCollider1;
    public string DamageCollider2;
    public string DamageCollider3;

    public CharacterAttributes ca;

    public bool AttackState;
    private Animator anim;


    public bool HaveWeapon;
    public bool HaveWeaponAxe;
    public bool HaveWeaponKnife;
    public bool HaveWeaponSword;
    public bool HaveWeaponSpear;

    public float AttackTime;
    public float setAttackTime;
    
    // Start is called before the first frame update
    void Start()
    {
        HaveWeaponAxe = false;
        HaveWeaponKnife = false;
        HaveWeaponSword = false;
        HaveWeaponSpear = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackInput();
        CalculateAttack();
    }

    void AttackInput() {
        if (AttackState == false && HaveWeapon == false) {
            if (Input.GetKeyDown(IM.XButton[ControlNumber])) {
                AttackState = true;
                AttackTime = setAttackTime;
            }
        }
        if (AttackState == false && HaveWeaponAxe == true) {
            if (Input.GetKeyDown(IM.XButton[ControlNumber])) {
                AttackState = true;
                AttackTime = setAttackTime;
            }
        }
        if (AttackState == false && HaveWeaponKnife == true)
        {
            if (Input.GetKeyDown(IM.XButton[ControlNumber]))
            {
                AttackState = true;
                AttackTime = setAttackTime;
            }
        }
        if (AttackState == false && HaveWeaponSword == true)
        {
            if (Input.GetKeyDown(IM.XButton[ControlNumber]) || Input.GetKeyDown(KeyCode.K))
            {
                AttackState = true;
                AttackTime = setAttackTime;
            }
        }
        if (AttackState == false && HaveWeaponSpear == true)
        {
            if (Input.GetKeyDown(IM.XButton[ControlNumber]))
            {
                AttackState = true;
                AttackTime = setAttackTime;
            }
        }
    }

    void CalculateAttack() {
        if (AttackTime > 0) {
            if (HaveWeapon == false) {
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackPunch", true);
            }
            if (HaveWeaponAxe == true) {
                //Senjata.GetComponent<BoxCollider>().enabled = true;
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackAxe", true);
            }
            if (HaveWeaponKnife == true)
            {
                //Senjata.GetComponent<BoxCollider>().enabled = true;
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackKnife", true);
            }
            if (HaveWeaponSword == true) {
                //Senjata.GetComponent<BoxCollider>().enabled = true;
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackSword", true);
            }
            if (HaveWeaponSpear == true) {
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackSpear", true);
            }
        }

        if (AttackTime < 0) {
            if (HaveWeapon == false)
            {
                AttackState = false;
                anim.SetBool("AttackPunch", false);
            }
            if (HaveWeaponAxe == true)
            {
                //Senjata.GetComponent<BoxCollider>().enabled = false;
                AttackState = false;
                anim.SetBool("AttackAxe", false);
            }
            if (HaveWeaponKnife == true)
            {
                //Senjata.GetComponent<BoxCollider>().enabled = false;
                AttackState = false;
                anim.SetBool("AttackKnife", false);
            }
            if (HaveWeaponSword == true)
            {
                //Senjata.GetComponent<BoxCollider>().enabled = false;
                AttackState = false;
                anim.SetBool("AttackSword", false);
            }
            if (HaveWeaponSpear == true)
            {
                AttackState = false;
                anim.SetBool("AttackSpear", false);
            }
        }
    }

    //void OnTriggerEnter(Collider coll) {
    //    if (coll.CompareTag(DamageCollider1)) {
    //        ca.AttackSuccess(0);
    //    }
    //}
}
