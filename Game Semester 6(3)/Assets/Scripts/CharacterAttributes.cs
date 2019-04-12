using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttributes : MonoBehaviour {

    public GameObject[] Player;

    public float[] CurrHealth;
    public float[] MaxHealth;
    public float[] CurrPowerBar;
    public float[] MaxPowerBar;

    public bool[] IsDamaged;
    public float[] InvicibilityLength;
    public float[] InvicibilityCounter;
    public float[] FlashCounter;
    public float[] FlashLength;

    public float amount;
    public SkinnedMeshRenderer[] PlayerRenderer;

    [Header("UI")]
    public float SetMaxHP;
    public float SetMaxPowerBar;
    public Image[] HealthBar;
    public Image[] PowerBar;

    [Header("Respawn")]
    public float[] RespawnLength;
    public bool[] isRespawning;
    public GameObject[] RespawnPoint;

    public bool[] IsUltiReady;
    public bool[] isHit;

    public Text[] SkorText;

    public int[] skorPlayer;

    public bool[] penandaLastHitPlayer1;
    public bool[] penandaLastHitPlayer2;
    public bool[] penandaLastHitPlayer3;
    public bool[] penandaLastHitPlayer4;

    // Use this for initialization
    void Start () {
        CurrHealth = new float[Player.Length];
        MaxHealth = new float[Player.Length];
        CurrPowerBar = new float[Player.Length];
        MaxPowerBar = new float[Player.Length];
        IsDamaged = new bool[Player.Length];
        //InvicibilityCounter = new float[Player.Length];
        //InvicibilityLength = new float[Player.Length];
        //FlashCounter = new float[Player.Length];
        //FlashLength = new float[Player.Length];
        isRespawning = new bool[Player.Length];
        //RespawnPoint = new GameObject[Player.Length];
        RespawnLength = new float[Player.Length];
        IsUltiReady = new bool[Player.Length];

        for (int i = 0; i < Player.Length; i++)
        {
            MaxHealth[i] = SetMaxHP;
            CurrHealth[i] = MaxHealth[i];
            MaxPowerBar[i] = SetMaxPowerBar;
            CurrPowerBar[i] = 0;
            PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
            HealthBar[i].fillAmount = CurrHealth[i] / MaxHealth[i];
        }
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Player.Length; i++) {
            if (IsDamaged[i] == true) {
                CalculateHealth(i);
            }
            if (CurrPowerBar[i] == SetMaxPowerBar) {
                IsUltiReady[i] = true;
            }
            if (isHit[i] == true) {
                AttackSuccess(i);
            }

            if (penandaLastHitPlayer2[i] == true) {
                ScoreCounter(i);
            }
            if (InvicibilityCounter[i] > 0)
            {
                InvicibilityCounter[i] -= Time.deltaTime;
                FlashCounter[i] -= Time.deltaTime;
                if (FlashCounter[i] <= 0)
                {
                    PlayerRenderer[i].enabled = !PlayerRenderer[i].enabled;
                    FlashCounter[i] = FlashLength[i];
                    Player[i].GetComponent<CharacterDamaged>().enabled = false;
                }
                if (InvicibilityCounter[i] <= 0)
                {
                    PlayerRenderer[i].enabled = true;
                    Player[i].GetComponent<CharacterDamaged>().enabled = true;
                }
            }
        }
    }

    public void AttackSuccess(int i) {
        CurrPowerBar[i] += amount;
        PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
        isHit[i] = false;
        if (CurrPowerBar[i] >= MaxPowerBar[i])
        {
            CurrPowerBar[i] = MaxPowerBar[i];
        }
    }
    
    void CalculateHealth(int i) {
        CurrHealth[i] -= amount;
        HealthBar[i].fillAmount = CurrHealth[i] / MaxHealth[i];
        IsDamaged[i] = false;
        if (CurrHealth[i] <= 0) {
            Respawning(i);
            InvicibilityCounter[i] = InvicibilityLength[i];
        }
    }

    public void ScoreCounter(int i)
    {
        skorPlayer[i]++;
        SkorText[i].text = " " + skorPlayer[i];
        penandaLastHitPlayer2[i] = false;
    }

    public void Respawning(int i)
    {
        if (!isRespawning[i])
        {
            StartCoroutine(RespawningCo(i));
        }
    }

    public IEnumerator RespawningCo(int i)
    {
        isRespawning[i] = true;
        Player[i].SetActive(false);
        Player[i].transform.position = RespawnPoint[i].transform.position;
        yield return new WaitForSeconds(RespawnLength[i]);
        isRespawning[i] = false;
        Player[i].SetActive(true);
        CurrHealth[i] = MaxHealth[i];
        CurrPowerBar[i] = 0;
        HealthBar[i].fillAmount = CurrHealth[i] / MaxHealth[i];
        PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
    }
}
