using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent == null)
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
