﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeUlti : MonoBehaviour
{

    public bool a;
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
        if (a)
        {

            if (other.gameObject.tag == "Player")
            {
                ca.Player[0].GetComponent<Animator>().SetTrigger("KnockbackUltiAxe");
            }
            if (other.gameObject.tag == "Player2")
            {
                ca.Player[1].GetComponent<Animator>().SetTrigger("KnockbackUltiAxe");
            }
            if (other.gameObject.tag == "Player3")
            {
                ca.Player[2].GetComponent<Animator>().SetTrigger("KnockbackUltiAxe");
            }
            if (other.gameObject.tag == "Player4")
            {
                ca.Player[3].GetComponent<Animator>().SetTrigger("KnockbackUltiAxe");
            }
        }
       
    }
}
