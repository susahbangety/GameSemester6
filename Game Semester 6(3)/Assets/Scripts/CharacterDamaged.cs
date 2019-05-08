using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamaged : MonoBehaviour {

    public int PlayerKeberapa;

    public CharacterAttributes ca;

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {

    }

    public void OnTriggerEnter(Collider coll) {
        if (PlayerKeberapa == 1 && ca.InvicibilityCounter[0] == 0) {
            if (coll.gameObject.tag == "WeaponPlayer2")
            {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[PlayerKeberapa] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount[1])
                {
                    ca.penandaLastHitPlayer1[PlayerKeberapa] = true;
                }
                else {
                    ca.penandaLastHitPlayer1[PlayerKeberapa] = false;
                } 
            }
            if (coll.gameObject.tag == "WeaponPlayer3")
            {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[PlayerKeberapa + 1] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount[2])
                {
                    ca.penandaLastHitPlayer1[PlayerKeberapa + 1] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer1[PlayerKeberapa + 1] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer4")
            {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[PlayerKeberapa + 2] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount[3])
                {
                    ca.penandaLastHitPlayer1[PlayerKeberapa + 2] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer1[PlayerKeberapa + 2] = false;
                }
            }
            if(coll.gameObject.tag == "DoubleDamageItem")
            {
                ca.powerUpDamage[PlayerKeberapa - 1] = true;
            }
            if (coll.gameObject.tag == "Healing") {
                ca.CurrHealth[PlayerKeberapa - 1] += 20;
                ca.HealthBar[PlayerKeberapa -1].fillAmount = ca.CurrHealth[PlayerKeberapa -1] / ca.MaxHealth[PlayerKeberapa -1];
            }
        }
        else if (PlayerKeberapa == 2 && ca.InvicibilityCounter[1] == 0) {
            if (coll.gameObject.tag == "WeaponPlayer1") {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[PlayerKeberapa - 2] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount[PlayerKeberapa - 2])
                {
                    ca.penandaLastHitPlayer2[PlayerKeberapa - 2] = true;
                }
                else {
                    ca.penandaLastHitPlayer2[PlayerKeberapa - 2] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer3") {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[PlayerKeberapa] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount[PlayerKeberapa])
                {
                    ca.penandaLastHitPlayer2[PlayerKeberapa] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer2[PlayerKeberapa] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer4")
            {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[PlayerKeberapa + 1] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount[PlayerKeberapa + 1])
                {
                    ca.penandaLastHitPlayer2[PlayerKeberapa + 1] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer2[PlayerKeberapa + 1] = false;
                }
            }
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                ca.powerUpDamage[PlayerKeberapa - 1] = true;
            }
            if (coll.gameObject.tag == "Healing")
            {
                ca.CurrHealth[PlayerKeberapa - 1] += 20;
                ca.HealthBar[PlayerKeberapa - 1].fillAmount = ca.CurrHealth[PlayerKeberapa - 1] / ca.MaxHealth[PlayerKeberapa - 1];
            }
        }
        else if (PlayerKeberapa == 3 && ca.InvicibilityCounter[2] == 0) {
            if (coll.gameObject.tag == "WeaponPlayer1")
            {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[PlayerKeberapa - 3] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount[0])
                {
                    ca.penandaLastHitPlayer3[PlayerKeberapa - 2] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer3[PlayerKeberapa - 2] = false;
                }
            }
            if (coll.gameObject.tag == "DoubleDamageItem")
            {
                ca.powerUpDamage[PlayerKeberapa - 1] = true;
            }
            if (coll.gameObject.tag == "Healing")
            {
                ca.CurrHealth[PlayerKeberapa - 1] += 20;
                ca.HealthBar[PlayerKeberapa - 1].fillAmount = ca.CurrHealth[PlayerKeberapa - 1] / ca.MaxHealth[PlayerKeberapa - 1];
            }
        }
    }
}
