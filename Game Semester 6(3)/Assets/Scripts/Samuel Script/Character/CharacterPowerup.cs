using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowerup : MonoBehaviour
{
    public int PlayerKeberapa;
    public CharacterAttributes ca;
    public AudioSource HealSound;
    public AudioSource DoubleDamageSound;

    //public ParticleSystem healingEffect;

    // Start is called before the first frame update
    void Start()
    {
        //healingEffect.Stop();
    }
    
    public void OnTriggerEnter(Collider coll) {
        if (PlayerKeberapa == 1 && ca.InvicibilityCounter[0] == 0) {
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                ca.powerUpDamage[0] = true;
                DoubleDamageSound.Play();
            }
            if (coll.gameObject.tag == "Healing")
            {
                //healingEffect.Play();
                HealSound.Play();
                ca.CurrHealth[0] += ca.CurrHealth[0] * 30 / 100;
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
                HealSound.Play();
                ca.CurrHealth[1] += ca.CurrHealth[1] * 30 / 100;
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
                ca.CurrHealth[2] += ca.CurrHealth[2] * 30 / 100;
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
                ca.CurrHealth[3] += ca.CurrHealth[3] * 30 / 100;
                if (ca.CurrHealth[3] >= ca.MaxHealth[3])
                {
                    ca.CurrHealth[3] = ca.MaxHealth[3];
                }
                ca.HealthBar[3].text = "" + ca.CurrHealth[3];
            }
        }
    }

    //IEnumerator stopHealingEffect()
    //{
    //    yield return new WaitForSeconds(.4f);

    //    healingEffect.Stop();
    //}
}
