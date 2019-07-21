using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeUlti : MonoBehaviour
{
    public EquipWeapon[] Player;
    public PlayerAttack[] Character;
    public bool flag;
    public int PlayerKeberapa;
  
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
        if (flag) {
            if (PlayerKeberapa == 1)
            {
                if (other.gameObject.tag == "Player2")
                {
                    asd(1);
                }
                if (other.gameObject.tag == "Player3")
                {
                    asd(2);
                }
                if (other.gameObject.tag == "Player4")
                {
                    asd(3);
                }
            }
            if (PlayerKeberapa == 2) {
                if (other.gameObject.tag == "Player")
                {
                    asd(0);
                }
                else if (other.gameObject.tag == "Player3")
                {
                    asd(2);
                }
                else if (other.gameObject.tag == "Player4")
                {
                    asd(3);
                }
            }
            
        }
    }

    void asd(int i)
    {
        Player[i].Axe.SetActive(false);
        Player[i].Sword.SetActive(false);
        Player[i].Hammer.SetActive(false);
        Player[i].Knife.SetActive(false);
        Player[i].Spear.SetActive(false);
        Player[i].weaponActive = false;
        Character[i].HaveWeapon = false;
        Character[i].HaveWeaponAxe = false;
        Character[i].HaveWeaponHammer = false;
        Character[i].HaveWeaponKnife = false;
        Character[i].HaveWeaponSpear = false;
        Character[i].HaveWeaponSword = false;
    }
}
