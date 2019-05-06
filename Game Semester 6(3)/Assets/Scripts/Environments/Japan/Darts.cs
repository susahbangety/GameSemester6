using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darts : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(3, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().PlayerStun();
            Destroy(gameObject);
        }
    }

}
