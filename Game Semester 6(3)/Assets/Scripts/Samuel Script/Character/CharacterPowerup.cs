using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowerup : MonoBehaviour
{
    public int PlayerKeberapa;
    public CharacterAttributes ca;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider coll) {
        if (PlayerKeberapa == 1 && ca.InvicibilityCounter[0] == 0) {
            if (coll.gameObject.tag == "DoubleDamageItem" && ca.powerUpDamage[PlayerKeberapa - 1] == false)
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
}
