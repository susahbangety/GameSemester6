using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("Buat Inputan")]
    public InputManager IM;
    public int ControlNumber;
    public int PlayerKeberapa;

    [Header("Senjata")]
    public GameObject Axe, Hammer, Sword, Spear, Knife;

    public CharacterAttributes ca;

    public bool AttackState;
    private Animator anim;

    public bool HaveWeapon;
    public bool HaveWeaponAxe;
    public bool HaveWeaponKnife;
    public bool HaveWeaponSword;
    public bool HaveWeaponSpear;
    public bool HaveWeaponHammer;

    public float AttackTime;
    public float setAttackTime;

    public bool isThrowing = false;
    public bool isThrowingKnife = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Axe.GetComponent<MeshCollider>().enabled = false;
        Sword.GetComponent<MeshCollider>().enabled = false;
        Hammer.GetComponent<MeshCollider>().enabled = false;
        Spear.GetComponent<MeshCollider>().enabled = false;
        HaveWeaponAxe = false;
        HaveWeaponKnife = false;
        HaveWeaponSword = false;
        HaveWeaponSpear = false;
        HaveWeaponHammer = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackInput();
        CalculateAttack();
        if (ca.IsUltiReady[0] == true && Input.GetKeyDown(IM.SquareButton[0])) {
            VerifyAttack(0);
            if (HaveWeapon == false) {
                UltiFist(0);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponAxe == true) {
                UltiAxe(0);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponHammer == true) {
                UltiHammer(0);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponKnife == true) {
                UltiKnife(0);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponSpear == true) {
                UltiSpear(0);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponSword == true) {
                UltiSword(0);
                AttackState = true;
                AttackTime = 2;
            }
        }
        if (ca.IsUltiReady[1] == true && Input.GetKeyDown(IM.SquareButton[1]))
        {
            VerifyAttack(1);
            if (HaveWeapon == false)
            {
                UltiFist(1);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponAxe == true)
            {
                UltiAxe(1);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponHammer == true)
            {
                UltiHammer(1);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponKnife == true)
            {
                UltiKnife(1);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponSpear == true)
            {
                UltiSpear(1);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponSword == true)
            {
                UltiSword(1);
                AttackState = true;
                AttackTime = 2;
            }
        }
        if (ca.IsUltiReady[2] == true && Input.GetKeyDown(IM.SquareButton[2]))
        {
            VerifyAttack(2);
            if (HaveWeapon == false)
            {
                UltiFist(2);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponAxe == true)
            {
                UltiAxe(2);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponHammer == true)
            {
                UltiHammer(2);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponKnife == true)
            {
                UltiKnife(2);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponSpear == true)
            {
                UltiSpear(2);
                AttackState = true;
                AttackTime = 2;
            }
            else if (HaveWeaponSword == true)
            {
                UltiSword(2);
                AttackState = true;
                AttackTime = 2;
            }
        }
        if (ca.IsUltiReady[3] == true && Input.GetKeyDown(IM.SquareButton[3]))
        {
            VerifyAttack(3);
            if (HaveWeapon == false)
            {
                UltiFist(3);
                AttackTime = 2;
                AttackState = true;
            }
            if (HaveWeaponAxe == true)
            {
                UltiAxe(3);
                AttackTime = 2;
                AttackState = true;
            }
            else if (HaveWeaponHammer == true)
            {
                UltiHammer(3);
                AttackTime = 2;
                AttackState = true;
            }
            else if (HaveWeaponKnife == true)
            {
                UltiKnife(3);
                AttackTime = 2;
                AttackState = true;
            }
            else if (HaveWeaponSpear == true)
            {
                UltiSpear(3);
                AttackTime = 2;
                AttackState = true;
            }
            else if (HaveWeaponSword == true)
            {
                UltiSword(3);
                AttackState = true;
                AttackTime = 2;
            }
        }
    }

    void VerifyAttack(int i)
    {
        ca.CurrPowerBar[i] = 0;
        ca.IsUltiReady[i] = false;
        ca.PowerBar[i].fillAmount = ca.CurrPowerBar[i] / ca.MaxPowerBar[i];
    }

    void UltiFist(int i) {
        anim.SetTrigger("UltiFist");
    }

    void UltiAxe(int i) {
        anim.SetTrigger("UltiAxe");
    }

    void UltiHammer(int i) {
        anim.SetTrigger("UltiHammer");
    }

    void UltiSword(int i) {
        anim.SetTrigger("UltiSword");
    }

    void UltiSpear(int i) {
        anim.SetTrigger("UltiSpear");
    }

    void UltiKnife(int i) {
        anim.SetTrigger("UltiKnife");
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
                anim.SetTrigger("AttackAxe");
            }
        }
        if (AttackState == false && HaveWeaponKnife == true)
        {
            if (Input.GetKeyDown(IM.XButton[ControlNumber]))
            {
                AttackState = true;
                AttackTime = setAttackTime;
                anim.SetTrigger("AttackKnife");
            }
        }
        if (AttackState == false && HaveWeaponSword == true)
        {
            if (Input.GetKeyDown(IM.XButton[ControlNumber]))
            {
                AttackState = true;
                AttackTime = setAttackTime;
                anim.SetTrigger("AttackSword");
            }
        }
        if (AttackState == false && HaveWeaponSpear == true)
        {
            if (Input.GetKeyDown(IM.XButton[ControlNumber]))
            {
                AttackState = true;
                AttackTime = setAttackTime;
                anim.SetTrigger("AttackSpear");
            }
        }
        if (AttackState == false && HaveWeaponHammer == true)
        {
            if (Input.GetKeyDown(IM.XButton[ControlNumber]))
            {
                AttackState = true;
                AttackTime = setAttackTime;
                anim.SetTrigger("AttackHammer");
            }
        }
    }

    void CalculateAttack() {
        if (AttackTime > 0) {
            if (HaveWeapon == false)
            {
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackPunch", true);
            }
            if (HaveWeaponAxe == true)
            {
                AttackTime -= Time.deltaTime;
            }
            if (HaveWeaponKnife == true)
            {
                AttackTime -= Time.deltaTime;
            }
            if (HaveWeaponSword == true) {
                AttackTime -= Time.deltaTime;
            }
            if (HaveWeaponSpear == true)
            {
                AttackTime -= Time.deltaTime;
            }
            if (HaveWeaponHammer == true)
            {
                AttackTime -= Time.deltaTime;
            }
        }

        if (AttackTime <= 0) {
            if (HaveWeapon == false)
            {
                AttackTime = 0;
                AttackState = false;
                anim.SetBool("AttackPunch", false);
            }
            if (HaveWeaponAxe == true)
            {
                AttackTime = 0;
                AttackState = false;
            }
            if (HaveWeaponKnife == true)
            {
                AttackState = false;
                AttackTime = 0;
            }
            if (HaveWeaponSword == true)
            {
                AttackTime = 0;
                AttackState = false;
            }
            if (HaveWeaponSpear == true)
            {
                AttackState = false;
                AttackTime = 0;
            }
            if (HaveWeaponHammer == true)
            {
                AttackState = false;
                AttackTime = 0;
            }
        }
    }
}
