﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamaged : MonoBehaviour {

    public int PlayerKeberapa;

    public CharacterAttributes ca;
    public Animator anim;

    public Transform[] Player;

    public AxeUlti KnockbackAxe;

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {

    }

    public void OnTriggerEnter (Collider coll) {
        if (PlayerKeberapa == 1 && ca.InvicibleState[0] == false)
        {
            if (coll.gameObject.tag == "WeaponPlayer2")
            {
                if (coll.gameObject.name == "KnifeEquip" || coll.gameObject.name == "ColliderTangan")
                {

                }
                else
                {
                    anim.SetTrigger("Knockback");
                }
                ca.CalculateHealth(0, 1);
                ca.isHit[1] = true;
                Vector3 look = Player[1].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
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
                ca.CalculateHealth(0, 2);
                ca.isHit[2] = true;
                Vector3 look = Player[2].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
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
                ca.CalculateHealth(0, 3);
                ca.isHit[3] = true;
                Vector3 look = Player[3].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            }

        }

        else if (PlayerKeberapa == 2 && ca.InvicibleState[1] == false)
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
                Vector3 look = Player[0].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
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
                Vector3 look = Player[2].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
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
                Vector3 look = Player[3].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            }
        }
        else if (PlayerKeberapa == 3 && ca.InvicibleState[2] == false)
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
                Vector3 look = Player[0].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
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
                Vector3 look = Player[1].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
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
                Vector3 look = Player[3].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            }
        }
        else if (PlayerKeberapa == 4 && ca.InvicibleState[3] == false)
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
                Vector3 look = Player[0].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
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
                Vector3 look = Player[1].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
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
                Vector3 look = Player[2].transform.position;
                look.y = 0;
                transform.LookAt(look);
                transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            }
        }
    }
}
