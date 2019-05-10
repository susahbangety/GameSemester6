using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2" || coll.gameObject.tag == "Player3" || coll.gameObject.tag == "Player4") {
            Destroy(gameObject);
        }
    }
}
