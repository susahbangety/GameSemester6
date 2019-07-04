using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearUlti : MonoBehaviour
{
    public GameObject[] Player;
    public bool a;
    public CharacterAttributes ca;
    public float SpearUltiDamage;
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
            if (other.gameObject.tag == "Player1")
            {
                Destroy(gameObject);
                Player[0].GetComponent<Animator>().SetTrigger("KnockbackUltiSpear");

            }
            if (other.gameObject.tag == "Player2")
            {
                Destroy(gameObject);
                Player[1].GetComponent<Animator>().SetTrigger("KnockbackUltiSpear");

            }
            if (other.gameObject.tag == "Player3")
            {
                Destroy(gameObject);
                Player[2].GetComponent<Animator>().SetTrigger("KnockbackUltiSpear");
 
            }
            if (other.gameObject.tag == "Player4")
            {
                Destroy(gameObject);
                Player[3].GetComponent<Animator>().SetTrigger("KnockbackUltiSpear");

            }
        }
    }
}
