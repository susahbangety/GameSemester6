using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamaged : MonoBehaviour {

    public string PlayerTag;
    [Header("DIISI TAGNYA")]
    public GameObject Player;

    public GameObject CharacterAttributesObject;
    public CharacterAttributes ca;

    [Header("DIISI NOMOR PLAYER --> 1/2/3/4")]
    public float PlayerTarget1;
    public float PlayerTarget2;
    public float PlayerTarget3;

    //Target
    [Header("DIISI TAG PLAYER")]
    public string Target1Tag;
    public string Target2Tag;
    public string Target3Tag;

    public GameObject Target1;
    public GameObject Target2;
    public GameObject Target3;

    public bool Target1Damaged;
    public bool Target2Damaged;
    public bool Target3Damaged;

    [Header("DIISI TAG DAMAGECOLLIDER TAG")]
    public string DamageCollider1;
    public string DamageCollider2;
    public string DamageCollider3;

    public float Damage;
    public float DamageMult;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(PlayerTag);

        PlayerTarget1 = PlayerTarget1 - 1;
        PlayerTarget2 = PlayerTarget2 - 1;
        PlayerTarget3 = PlayerTarget2 - 1;

        CharacterAttributesObject = GameObject.FindGameObjectWithTag("CharacterAttributes");
        ca = CharacterAttributesObject.GetComponent<CharacterAttributes>();

        Target1 = GameObject.FindGameObjectWithTag(Target1Tag);
        Target2 = GameObject.FindGameObjectWithTag(Target2Tag);
        Target3 = GameObject.FindGameObjectWithTag(Target3Tag);

        DamageMult = 1;
    }

    private void Update()
    {
        Damage = 10 * DamageMult;
    }
    //private void ontriggerenter(collider collision)
    //{
    //    if (collision.comparetag(damagecollider1))
    //    {
    //        ca.sendmessageupwards("damaged", new vector2(playertarget1, damage));
    //        target1damaged = true;
    //    }
    //    if (collision.comparetag(damagecollider2))
    //    {
    //        ca.sendmessageupwards("damaged", new vector2(playertarget2, damage));
    //        target2damaged = true;
    //    }
    //}
}
