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
        if (PlayerKeberapa == 1) {
            if (coll.gameObject.tag == "WeaponPlayer2")
            {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[1] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount)
                {
                    ca.penandaLastHitPlayer1[1] = true;
                }
                else {
                    ca.penandaLastHitPlayer1[1] = false;
                } 
            }
            if (coll.gameObject.tag == "WeaponPlayer3")
            {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[PlayerKeberapa + 1] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount)
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
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount)
                {
                    ca.penandaLastHitPlayer1[PlayerKeberapa + 2] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer1[PlayerKeberapa + 2] = false;
                }
            }
        }
        if (PlayerKeberapa == 2) {
            if (coll.gameObject.tag == "WeaponPlayer1") {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.isHit[PlayerKeberapa - 2] = true;
                if (ca.CurrHealth[PlayerKeberapa - 1] <= ca.amount)
                {
                    ca.penandaLastHitPlayer2[PlayerKeberapa - 2] = true;
                }
                else {
                    ca.penandaLastHitPlayer2[PlayerKeberapa - 2] = false;
                }
            }
        }
    }
}
