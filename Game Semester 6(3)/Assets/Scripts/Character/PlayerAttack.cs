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

    public ParticleSystem axeParticle;
    public ParticleSystem swordParticle;

    // Start is called before the first frame update
    void Start()
    {
        Axe.GetComponent<BoxCollider>().enabled = false;
        Sword.GetComponent<BoxCollider>().enabled = false;
        Hammer.GetComponent<BoxCollider>().enabled = false;
        Spear.GetComponent<BoxCollider>().enabled = false;
        HaveWeaponAxe = false;
        HaveWeaponKnife = false;
        HaveWeaponSword = false;
        HaveWeaponSpear = false;
        HaveWeaponHammer = false;
        anim = GetComponent<Animator>();
        axeParticle.Stop();
        axeParticle.enableEmission = false;
        swordParticle.Stop();
        swordParticle.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        AttackInput();
        CalculateAttack();
        for (int i = 0; i < ca.Player.Length; i++) {
            if (ca.IsUltiReady[i] == true && Input.GetKeyDown(IM.SquareButton[ControlNumber])) {
                ca.CurrPowerBar[i] = 0;
                ca.IsUltiReady[i] = false;
                ca.PowerBar[i].fillAmount = ca.CurrPowerBar[i] / ca.MaxPowerBar[i];
            }
        }
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
            if (HaveWeapon == false) {
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackPunch", true);
            }
            if (HaveWeaponAxe == true) {
                axeParticle.Play();
                axeParticle.enableEmission = true;
                AttackTime -= Time.deltaTime;
            }
            if (HaveWeaponKnife == true)
            {
                AttackTime -= Time.deltaTime;
            }
            if (HaveWeaponSword == true) {
                swordParticle.Play();
                swordParticle.enableEmission = true;
                AttackTime -= Time.deltaTime;
            }
            if (HaveWeaponSpear == true) {

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
                AttackState = false;
                anim.SetBool("AttackPunch", false);
            }
            if (HaveWeaponAxe == true)
            {
                axeParticle.Stop();
                axeParticle.enableEmission = false;
                AttackState = false;
            }
            if (HaveWeaponKnife == true)
            {
                AttackState = false;
             
            }
            if (HaveWeaponSword == true)
            {
                swordParticle.Stop();
                swordParticle.enableEmission = false;
                AttackState = false;
            }
            if (HaveWeaponSpear == true)
            {
                AttackState = false;
            }
            if (HaveWeaponHammer == true)
            {
                AttackState = false;
            }
        }
    }
}
