using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JatuhRespawn : MonoBehaviour
{

    public CharacterAttributes ca;

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
        if (other.gameObject.tag == "Player") {
            ca.Respawning(0);
            ca.InvicibilityCounter[0] = ca.InvicibilityLength[0];
        }
        if (other.gameObject.tag == "Player2")
        {
            ca.RespawningCo(1);
            ca.InvicibilityCounter[1] = ca.InvicibilityLength[1];
        }
        if (other.gameObject.tag == "Player3")
        {
            ca.Respawning(2);
            ca.InvicibilityCounter[2] = ca.InvicibilityLength[2];
        }
        if (other.gameObject.tag == "Player4")
        {
            ca.Respawning(3);
            ca.InvicibilityCounter[3] = ca.InvicibilityLength[3];
        }
    }
}
