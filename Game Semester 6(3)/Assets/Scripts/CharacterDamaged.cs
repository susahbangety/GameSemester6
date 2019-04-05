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
                ca.AttackSuccess(1);
            }
        }
        if (PlayerKeberapa == 2) {
            if (coll.gameObject.tag == "WeaponPlayer1") {
                ca.IsDamaged[PlayerKeberapa - 1] = true;
                ca.AttackSuccess(0);
            }
        }
    }
}
