using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeUlti : MonoBehaviour
{

    public GameObject[] Player;
    public bool a;

    public float WaktuKnockback;

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
                Player[0].GetComponent<Animator>().SetTrigger("KnockbackUltiAxe");
                StartCoroutine(BiarNggaBisaGerak(0));
            }
            if (other.gameObject.tag == "Player2")
            {
                Player[1].GetComponent<Animator>().SetTrigger("KnockbackUltiAxe");
                StartCoroutine(BiarNggaBisaGerak(1));
            }
            if (other.gameObject.tag == "Player3")
            {
                Player[2].GetComponent<Animator>().SetTrigger("KnockbackUltiAxe");
            }
            if (other.gameObject.tag == "Player4")
            {
                Player[3].GetComponent<Animator>().SetTrigger("KnockbackUltiAxe");
            }
        }
       
    }
    public IEnumerator BiarNggaBisaGerak(int i) {
        Player[i].GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(WaktuKnockback);
        Player[i].GetComponent<PlayerMovement>().enabled = true;
    }
}
