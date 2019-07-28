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
            ca.Player[0].transform.position = ca.RespawnPoint[0].transform.position;
            ca.ScoreMinus(0);
        }
        if (other.gameObject.tag == "Player2")
        {
            ca.Respawning(1);
            ca.Player[1].transform.position = ca.RespawnPoint[1].transform.position;
            ca.ScoreMinus(1);
        }
        if (other.gameObject.tag == "Player3")
        {
            ca.Respawning(2);
            ca.ScoreMinus(2);
        }
        if (other.gameObject.tag == "Player4")
        {
            ca.Respawning(3);
            ca.ScoreMinus(3);
        }
    }
}
