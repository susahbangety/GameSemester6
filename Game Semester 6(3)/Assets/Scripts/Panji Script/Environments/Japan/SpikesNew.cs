using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesNew : MonoBehaviour
{
    //public GameObject Player1;
    //public GameObject Player2;

    //public PlayerMovement PM1;
    //public PlayerMovement PM2;

    //void Start()
    //{
    //    Player1 = GameObject.FindGameObjectWithTag("Player");
    //    PM1 = Player1.GetComponent<PlayerMovement>();

    //    Player2 = GameObject.FindGameObjectWithTag("Player");
    //    PM2 = Player2.GetComponent<PlayerMovement>();

    //}
    //void Update()
    //{

    //}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<PlayerMovement>().PlayerSlow();
            Destroy(gameObject);
        }
    }
}
