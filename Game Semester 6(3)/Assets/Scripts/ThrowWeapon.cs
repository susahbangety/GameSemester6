using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    public float speed;
    public Vector3 axePos;

    public EquipWeapon equip;
    public pickupItem pickup;
    public InputManager IM;
    public PlayerAttack patt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    void throwing()
    {
        if(equip.currWeapon == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                gameObject.GetComponent<Animator>().SetBool("Throwing", true);
                pickup.throwWeapon();
            }
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Throwing", false);
        } 
    }
}
