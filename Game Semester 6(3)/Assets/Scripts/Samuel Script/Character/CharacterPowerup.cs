using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowerup : MonoBehaviour
{
    public int PlayerKeberapa;
    public CharacterAttributes ca;
    public AudioSource HealSound;
    public AudioSource DoubleDamageSound;

    //public GameObject 

    //public GameObject DoubleDamageImage;
    public ParticleSystem healingEffect1;
    public ParticleSystem healingEffect2;
    private float AMOUNTNAMBAHDARAH = 20;

    // Start is called before the first frame update
    void Start()
    {
        //DoubleDamageImage.SetActive(false);
        healingEffect1.Stop();
        healingEffect2.Stop();
    }
    
    public void OnTriggerEnter(Collider coll) {
        if (PlayerKeberapa == 1 && ca.InvicibilityCounter[0] == 0) {
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                ca.powerUpDamage[0] = true;
                //DoubleDamageImage.SetActive(true);
                DoubleDamageSound.Play();
                //StartCoroutine(stopDoubleDamage());
            }
            if (coll.gameObject.tag == "Healing")
            {
                if (ca.CurrHealth[0] >= 100)
                {
                    healingEffect1.Stop();
                    HealSound.Play();
                }
                else
                {
                    healingEffect1.Play();
                    HealSound.Play();
                    StartCoroutine(stopHealingEffect());
                    ca.CurrHealth[0] += AMOUNTNAMBAHDARAH;
                }
                if (ca.CurrHealth[0] >= ca.MaxHealth[0])
                {
                    ca.CurrHealth[0] = ca.MaxHealth[0];
                }
                ca.HealthBar[0].text = "" + ca.CurrHealth[0];
            }
        }
        if (PlayerKeberapa == 2 && ca.InvicibilityCounter[1] == 0)
        {
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                DoubleDamageSound.Play();
                ca.powerUpDamage[1] = true;
            }
            if (coll.gameObject.tag == "Healing")
            {
                if (ca.CurrHealth[1] >= 100)
                {
                    healingEffect2.Stop();
                    HealSound.Play();
                }
                else
                {
                    HealSound.Play();
                    healingEffect2.Play();
                    StartCoroutine(stopHealingEffect());
                    ca.CurrHealth[1] += AMOUNTNAMBAHDARAH;
                }
                if (ca.CurrHealth[1] >= ca.MaxHealth[1])
                {
                    ca.CurrHealth[1] = ca.MaxHealth[1];
                }
                ca.HealthBar[1].text = "" + ca.CurrHealth[1];
            }
        }
        if (PlayerKeberapa == 3 && ca.InvicibilityCounter[2] == 0)
        {
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                DoubleDamageSound.Play();
                ca.powerUpDamage[2] = true;
            }
            if (coll.gameObject.tag == "Healing")
            {
                HealSound.Play();
                ca.CurrHealth[2] += AMOUNTNAMBAHDARAH;
                if (ca.CurrHealth[2] >= ca.MaxHealth[2])
                {
                    ca.CurrHealth[2] = ca.MaxHealth[2];
                }
                ca.HealthBar[2].text = "" + ca.CurrHealth[2];
            }
        }
        if (PlayerKeberapa == 4 && ca.InvicibilityCounter[3] == 0)
        {
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                DoubleDamageSound.Play();
                ca.powerUpDamage[3] = true;
            }
            if (coll.gameObject.tag == "Healing")
            {
                HealSound.Play();
                ca.CurrHealth[3] += AMOUNTNAMBAHDARAH;
                if (ca.CurrHealth[3] >= ca.MaxHealth[3])
                {
                    ca.CurrHealth[3] = ca.MaxHealth[3];
                }
                ca.HealthBar[3].text = "" + ca.CurrHealth[3];
            }
        }
    }

    IEnumerator stopHealingEffect()
    {
        yield return new WaitForSeconds(1f);
        if (PlayerKeberapa == 1)
        {
            healingEffect1.Stop();
        }
        else if (PlayerKeberapa == 2)
        {
            healingEffect2.Stop();
        }
    }

    //IEnumerator stopDoubleDamage()
    //{
    //    yield return new WaitForSeconds(10f);

    //    DoubleDamageImage.SetActive(false);
    //}
}
