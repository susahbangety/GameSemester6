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
        if (ca.IsUltiReady[0] == true && Input.GetKeyDown(IM.LeftBumper[ControlNumber])) {
            Debug.Log(PlayerKeberapa + "lagi ulti");
            ca.CurrPowerBar[PlayerKeberapa - 1] = 0;
            ca.IsUltiReady[PlayerKeberapa - 1] = false;
            ca.PowerBar[PlayerKeberapa - 1].fillAmount = ca.CurrPowerBar[PlayerKeberapa] / ca.MaxPowerBar[PlayerKeberapa];
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
        if (AttackState == false && HaveWeaponHammer == true)
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
                Axe.GetComponent<BoxCollider>().enabled = true;
                axeParticle.Play();
                axeParticle.enableEmission = true;
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackAxe", true);
            }
            if (HaveWeaponKnife == true)
            {
                Knife.GetComponent<BoxCollider>().enabled = true;
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackKnife", true);
            }
            if (HaveWeaponSword == true) {
                Sword.GetComponent<BoxCollider>().enabled = true;
                swordParticle.Play();
                swordParticle.enableEmission = true;
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackSword", true);
            }
            if (HaveWeaponSpear == true) {
                Spear.GetComponent<BoxCollider>().enabled = true;
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackSpear", true);
            }
            if (HaveWeaponHammer == true)
            {
                Hammer.GetComponent<BoxCollider>().enabled = true;
                AttackTime -= Time.deltaTime;
                anim.SetBool("AttackHammer", true);
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
                Axe.GetComponent<BoxCollider>().enabled = false;
                axeParticle.Stop();
                axeParticle.enableEmission = false;
                AttackState = false;
                anim.SetBool("AttackAxe", false);
            }
            if (HaveWeaponKnife == true)
            {
                Knife.GetComponent<BoxCollider>().enabled = false;
                AttackState = false;
                anim.SetBool("AttackKnife", false);
             
            }
            if (HaveWeaponSword == true)
            {
                Sword.GetComponent<BoxCollider>().enabled = false;
                swordParticle.Stop();
                swordParticle.enableEmission = false;
                AttackState = false;
                anim.SetBool("AttackSword", false);
            }
            if (HaveWeaponSpear == true)
            {
                Spear.GetComponent<BoxCollider>().enabled = false;
                AttackState = false;
                anim.SetBool("AttackSpear", false);
            }
            if (HaveWeaponHammer == true)
            {
                Hammer.GetComponent<BoxCollider>().enabled = false;
                AttackState = false;
                anim.SetBool("AttackHammer", false);
            }
        }
    }
}
