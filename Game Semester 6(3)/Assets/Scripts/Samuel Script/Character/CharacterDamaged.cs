using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamaged : MonoBehaviour
{

    public int PlayerKeberapa;

    public CharacterAttributes ca;
    public Animator anim;
    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {

    }

    public void OnTriggerEnter(Collider coll)
    {
        if (PlayerKeberapa == 1 && ca.InvicibilityCounter[0] == 0)
        {
            if (coll.gameObject.tag == "WeaponPlayer2")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                    //Vector3 look = coll.transform.position;
                    //look.y = 0;
                    //transform.LookAt(look);
                }
                ca.CalculateHealth(0, 1);
                ca.isHit[1] = true;
                if (ca.CurrHealth[0] <= ca.amountDamage[1])
                {
                    ca.penandaLastHitPlayer1[1] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer1[1] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer3")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                    //Vector3 look = coll.transform.position;
                    //look.y = 0;
                    //transform.LookAt(look);
                }
                ca.CalculateHealth(0, 2);
                ca.isHit[2] = true;
                if (ca.CurrHealth[0] <= ca.amountDamage[2])
                {
                    ca.penandaLastHitPlayer1[2] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer1[2] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer4")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                    //Vector3 look = coll.transform.position;
                    //look.y = 0;
                    //transform.LookAt(look);
                }
                ca.CalculateHealth(0, 3);
                ca.isHit[3] = true;
                if (ca.CurrHealth[0] <= ca.amountDamage[3])
                {
                    ca.penandaLastHitPlayer1[3] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer1[3] = false;
                }
            }
        }

        else if (PlayerKeberapa == 2 && ca.InvicibilityCounter[1] == 0)
        {
            if (coll.gameObject.tag == "WeaponPlayer1")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(1, 0);
                ca.isHit[0] = true;
                if (ca.CurrHealth[1] <= ca.amountDamage[0])
                {
                    ca.penandaLastHitPlayer2[0] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer2[0] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer3")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(1, 2);
                ca.isHit[2] = true;
                if (ca.CurrHealth[1] <= ca.amountDamage[2])
                {
                    ca.penandaLastHitPlayer2[2] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer2[2] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer4")
            {

                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(1, 3);
                ca.isHit[3] = true;
                if (ca.CurrHealth[1] <= ca.amountDamage[3])
                {
                    ca.penandaLastHitPlayer2[3] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer2[3] = false;
                }
            }
        }
        else if (PlayerKeberapa == 3 && ca.InvicibilityCounter[2] == 0)
        {
            if (coll.gameObject.tag == "WeaponPlayer1")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(2, 0);
                ca.isHit[0] = true;
                if (ca.CurrHealth[1] <= ca.amountDamage[0])
                {
                    ca.penandaLastHitPlayer3[0] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer3[0] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer2")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(2, 1);
                ca.isHit[1] = true;
                if (ca.CurrHealth[2] <= ca.amountDamage[1])
                {
                    ca.penandaLastHitPlayer3[1] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer3[1] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer4")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(2, 3);
                ca.isHit[3] = true;
                if (ca.CurrHealth[2] <= ca.amountDamage[3])
                {
                    ca.penandaLastHitPlayer3[3] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer3[3] = false;
                }
            }
        }
        else if (PlayerKeberapa == 4 && ca.InvicibilityCounter[3] == 0)
        {
            if (coll.gameObject.tag == "WeaponPlayer1")
            {

                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(3, 0);
                ca.isHit[0] = true;
                if (ca.CurrHealth[3] <= ca.amountDamage[0])
                {
                    ca.penandaLastHitPlayer4[0] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer4[0] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer2")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(3, 1);
                ca.isHit[1] = true;
                if (ca.CurrHealth[3] <= ca.amountDamage[1])
                {
                    ca.penandaLastHitPlayer4[1] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer4[1] = false;
                }
            }
            if (coll.gameObject.tag == "WeaponPlayer3")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(3, 2);
                ca.isHit[2] = true;
                if (ca.CurrHealth[3] <= ca.amountDamage[2])
                {
                    ca.penandaLastHitPlayer4[2] = true;
                }
                else
                {
                    ca.penandaLastHitPlayer4[2] = false;
                }
            }
        }
    }
}
