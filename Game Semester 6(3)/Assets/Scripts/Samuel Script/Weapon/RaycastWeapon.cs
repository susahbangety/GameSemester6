using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{

    public float TargetDistance;
    public ParticleSystem particleHurt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit theHit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theHit)) {
            TargetDistance = theHit.distance;
        }
        if (TargetDistance <= 0.1) {
            particleHurt.Play();
        }
    }
}
