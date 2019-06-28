using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darts : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 3) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<PlayerMovement>().PlayerStun();
            Destroy(gameObject);
        }
    }

}
