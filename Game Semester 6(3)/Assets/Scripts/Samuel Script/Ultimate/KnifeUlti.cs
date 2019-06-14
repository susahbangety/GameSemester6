using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeUlti : MonoBehaviour
{
    public EquipWeapon[] Player;
    public PlayerAttack[] Character;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1") {
            Player[0].Axe.SetActive(false);
            Player[0].Sword.SetActive(false);
            Player[0].Hammer.SetActive(false);
            Player[0].Knife.SetActive(false);
            Player[0].Spear.SetActive(false);
            Player[0].weaponActive = false;
            Character[0].HaveWeaponAxe = false;
            Character[0].HaveWeaponHammer = false;
            Character[0].HaveWeaponKnife = false;
            Character[0].HaveWeaponSpear = false;
            Character[0].HaveWeaponSword = false;

        }
        if (other.gameObject.tag == "Player2") {
            Player[1].Axe.SetActive(false);
            Player[1].Sword.SetActive(false);
            Player[1].Hammer.SetActive(false);
            Player[1].Knife.SetActive(false);
            Player[1].Spear.SetActive(false);
            Player[1].weaponActive = false;
            Character[1].HaveWeaponAxe = false;
            Character[1].HaveWeaponHammer = false;
            Character[1].HaveWeaponKnife = false;
            Character[1].HaveWeaponSpear = false;
            Character[1].HaveWeaponSword = false;
        }
        if (other.gameObject.tag == "Player3") {
            Player[2].Axe.SetActive(false);
            Player[2].Sword.SetActive(false);
            Player[2].Hammer.SetActive(false);
            Player[2].Knife.SetActive(false);
            Player[2].Spear.SetActive(false);
            Player[2].weaponActive = false;
            Character[2].HaveWeaponAxe = false;
            Character[2].HaveWeaponHammer = false;
            Character[2].HaveWeaponKnife = false;
            Character[2].HaveWeaponSpear = false;
            Character[2].HaveWeaponSword = false;
        }
        if (other.gameObject.tag == "Player4") {
            Player[3].Axe.SetActive(false);
            Player[3].Sword.SetActive(false);
            Player[3].Hammer.SetActive(false);
            Player[3].Knife.SetActive(false);
            Player[3].Spear.SetActive(false);
            Player[3].weaponActive = false;
            Character[3].HaveWeaponAxe = false;
            Character[3].HaveWeaponHammer = false;
            Character[3].HaveWeaponKnife = false;
            Character[3].HaveWeaponSpear = false;
            Character[3].HaveWeaponSword = false;
        }
    }
}
