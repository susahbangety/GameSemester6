using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowerup : MonoBehaviour
{
    public int PlayerKeberapa;
    public CharacterAttributes ca;

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
                ca.powerUpDamage[PlayerKeberapa - 1] = true;
            }
            if (coll.gameObject.tag == "Healing")
            {
                //healingEffect.Play();
                ca.CurrHealth[PlayerKeberapa - 1] += ca.CurrHealth[PlayerKeberapa - 1] * 30 / 100;
                if (ca.CurrHealth[PlayerKeberapa - 1] >= ca.MaxHealth[PlayerKeberapa - 1])
                {
                    ca.CurrHealth[PlayerKeberapa - 1] = ca.MaxHealth[PlayerKeberapa - 1];
                }
                ca.HealthBar[PlayerKeberapa - 1].text = "" + ca.CurrHealth[PlayerKeberapa - 1];
                
            }
        }
        if (PlayerKeberapa == 2 && ca.InvicibilityCounter[1] == 0)
        {
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                ca.powerUpDamage[PlayerKeberapa - 1] = true;
            }
            if (coll.gameObject.tag == "Healing")
            {
                ca.CurrHealth[PlayerKeberapa - 1] += ca.CurrHealth[PlayerKeberapa - 1] * 30 / 100;
                if (ca.CurrHealth[PlayerKeberapa - 1] >= ca.MaxHealth[PlayerKeberapa - 1])
                {
                    ca.CurrHealth[PlayerKeberapa - 1] = ca.MaxHealth[PlayerKeberapa - 1];
                }
                ca.HealthBar[PlayerKeberapa - 1].text = "" + ca.CurrHealth[PlayerKeberapa - 1];
            }
        }
        if (PlayerKeberapa == 3 && ca.InvicibilityCounter[2] == 0)
        {
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                ca.powerUpDamage[PlayerKeberapa - 1] = true;
            }
            if (coll.gameObject.tag == "Healing")
            {
                ca.CurrHealth[PlayerKeberapa - 1] += ca.CurrHealth[PlayerKeberapa - 1] * 30 / 100;
                if (ca.CurrHealth[PlayerKeberapa - 1] >= ca.MaxHealth[PlayerKeberapa - 1])
                {
                    ca.CurrHealth[PlayerKeberapa - 1] = ca.MaxHealth[PlayerKeberapa - 1];
                }
                ca.HealthBar[PlayerKeberapa - 1].text = "" + ca.CurrHealth[PlayerKeberapa - 1];
            }
        }
        if (PlayerKeberapa == 4 && ca.InvicibilityCounter[3] == 0)
        {
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                ca.powerUpDamage[PlayerKeberapa - 1] = true;
            }
            if (coll.gameObject.tag == "Healing")
            {
                ca.CurrHealth[PlayerKeberapa - 1] += ca.CurrHealth[PlayerKeberapa - 1] * 30 / 100;
                if (ca.CurrHealth[PlayerKeberapa - 1] >= ca.MaxHealth[PlayerKeberapa - 1])
                {
                    ca.CurrHealth[PlayerKeberapa - 1] = ca.MaxHealth[PlayerKeberapa - 1];
                }
                ca.HealthBar[PlayerKeberapa - 1].text = "" + ca.CurrHealth[PlayerKeberapa - 1];
            }
        }
    }

    //IEnumerator stopHealingEffect()
    //{
    //    yield return new WaitForSeconds(.4f);

    //    healingEffect.Stop();
    //}
}
