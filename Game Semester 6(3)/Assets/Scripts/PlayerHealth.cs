using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

    public Image HealthBar;
    public Image PowerBar;

    public float InviciblityLength;
    public float InvicibilityCounter;
    private float FlashCounter;
    public float FlashLength;

    public float MaxHealth = 100f;
    public float CurrHealth = 0f;
    public float MaxPowerBar = 100f;
    public float CurrPowerBar = 0f;
    Animator anim;

    private SkinnedMeshRenderer PlayerRenderer;


    // Use this for initialization
    void Start() {
        PlayerRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        anim = GetComponent<Animator>();
        CurrHealth = MaxHealth;
        CurrPowerBar = 0;
        PowerBar.fillAmount = CurrPowerBar / MaxPowerBar;
    }

    // Update is called once per frame
    void Update() {
    //    if (InvicibilityCounter > 0) {
    //        InvicibilityCounter -= Time.deltaTime;
    //        FlashCounter -= Time.deltaTime;
    //        if (FlashCounter <= 0) {
    //            PlayerRenderer.enabled = !PlayerRenderer.enabled;
    //            FlashCounter = FlashLength;
    //        }
    //        if (InvicibilityCounter <= 0) {
    //            PlayerRenderer.enabled = true;
    //        }
    //    }
    //    HealthBar.fillAmount = CurrHealth / MaxHealth;
    }

    public void takeDamage(float amount) {
        if (InvicibilityCounter <= 0)
        {
            CurrHealth -= amount;
            HealthBar.fillAmount = CurrHealth / MaxHealth;
            InvicibilityCounter = InviciblityLength;
            PlayerRenderer.enabled = false;
            FlashCounter = FlashLength;

        }
        if (CurrHealth <= 0)
        {

        }  
    }

    public void DoDamage(float amount) {
        CurrPowerBar += amount;
        PowerBar.fillAmount = CurrPowerBar / MaxPowerBar;

        if (CurrPowerBar >= MaxPowerBar) {
            CurrPowerBar = MaxPowerBar;
            UltimateSkillActivated();
        }
    }

    public void UltimateSkillActivated(){
        //do something;
        CurrPowerBar = 0;
    } 

    public void OnTriggerEnter(Collider coll) {
        if(coll.gameObject.name == "Player2")
        {
            DoDamage(10);
        }
    }
}
