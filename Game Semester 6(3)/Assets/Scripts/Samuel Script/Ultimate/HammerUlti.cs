using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerUlti : MonoBehaviour
{

    public PlayerMovement[] Player;
    public bool flag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (flag) {
            if (other.gameObject.tag == "Player")
            {
                Player[0].PlayerStun();
            }
            if (other.gameObject.tag == "Player2")
            {
                Player[1].PlayerStun();
            }
            if (other.gameObject.tag == "Player3")
            {
                Player[2].PlayerStun();
            }
            if (other.gameObject.tag == "Player4")
            {
                Player[3].PlayerStun();
            }
        }
    }
}
