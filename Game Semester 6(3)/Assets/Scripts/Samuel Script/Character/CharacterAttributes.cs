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

    public float[] InvicibilityLength;
    public float[] InvicibilityCounter;
    public float[] FlashCounter;
    public float[] FlashLength;
    public bool[] IsDamaged;

    public float[] amountPowerBar;
    public float[] amountDamage;
    public SkinnedMeshRenderer[] PlayerRenderer;

    [Header("UI")]
    public float SetMaxHP;
    public float SetMaxPowerBar;
    public Text[] HealthBar;
    public Image[] PowerBar;
    public ParticleSystem[] GlowBar;

    [Header("Respawn")]
    public float[] RespawnLength;
    public bool[] isRespawning;
    public GameObject[] RespawnPoint;

    public bool[] IsUltiReady;
    public bool[] isHit;


    public Text[] SkorText;
    public int[] skorPlayer;
    public int[] tempSkorPlayer;

    public Image[] playerCrown;

    public bool[] penandaLastHitPlayer1;
    public bool[] penandaLastHitPlayer2;
    public bool[] penandaLastHitPlayer3;
    public bool[] penandaLastHitPlayer4;

    public float amountOverTime;


    public float powerUpTime;
    public bool[] powerUpDamage;

    public int[] playerDeath;

    // Use this for initialization
    void Start() {
        CurrHealth = new float[Player.Length];
        MaxHealth = new float[Player.Length];
        CurrPowerBar = new float[Player.Length];
        MaxPowerBar = new float[Player.Length];
        isRespawning = new bool[Player.Length];
        IsDamaged = new bool[Player.Length];
        RespawnLength = new float[Player.Length];
        IsUltiReady = new bool[Player.Length];
        amountPowerBar = new float[Player.Length];
        amountDamage = new float[Player.Length];

        for (int i = 0; i < Player.Length; i++)
        {
            MaxHealth[i] = SetMaxHP;
            CurrHealth[i] = MaxHealth[i];
            MaxPowerBar[i] = SetMaxPowerBar;
            CurrPowerBar[i] = 0;
            PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
            HealthBar[i].text = "" + CurrHealth[i];
            playerCrown[i].enabled = false;
            amountPowerBar[i] = 10;
            powerUpDamage[i] = false;
            amountDamage[i] = 5;
            IsDamaged[i] = false;
        }
    }

    // Update is called once per frame
    void Update() {

        //if (Input.GetKeyDown(KeyCode.U)) {
        //    SortScore();
        //}
        //if (Input.GetKeyDown(KeyCode.T)) {
        //    findHighestScore();
        //}

        for (int i = 0; i < Player.Length; i++) {
            PowerBarOverTime(i);

            if (CurrPowerBar[i] == SetMaxPowerBar) {
                IsUltiReady[i] = true;
            }
            if (isHit[i] == true) {
                AttackSuccess(i);
            }

            if (penandaLastHitPlayer2[i] == true) {
                ScoreCounter(i);
            }
            if (penandaLastHitPlayer1[i] == true)
            {
                ScoreCounter(i);
            }

            if (powerUpDamage[i] == true) {
                StartCoroutine(DoubleDamage(i));
            }

            if (InvicibilityCounter[i] > 0)
            {
                InvicibilityCounter[i] -= Time.deltaTime;
                FlashCounter[i] -= Time.deltaTime;
                Player[i].GetComponent<CharacterDamaged>().enabled = false;
                if (FlashCounter[i] <= 0)
                {
                    PlayerRenderer[i].enabled = !PlayerRenderer[i].enabled;
                    FlashCounter[i] = FlashLength[i];
                }
                if (InvicibilityCounter[i] < 0)
                {
                    InvicibilityCounter[i] = 0;
                    PlayerRenderer[i].enabled = true;
                    Player[i].GetComponent<CharacterDamaged>().enabled = true;
                }
            }
        }
    }

    public void AttackSuccess(int i) {
        CurrPowerBar[i] += amountPowerBar[i];
        PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
        isHit[i] = false;
        if (CurrPowerBar[i] >= MaxPowerBar[i])
        {
            CurrPowerBar[i] = MaxPowerBar[i];
        }
    }

    public void CalculateHealth(int i, int j) {
        if (IsDamaged[i] == false)
        {
            CurrHealth[i] -= amountDamage[j];
            StartCoroutine(DelayDamage(i));
            Debug.Log("damage " + amountDamage[j]);
            HealthBar[i].text = "" + CurrHealth[i];
            if (CurrHealth[i] <= 0)
            {
                Respawning(i);
                InvicibilityCounter[i] = InvicibilityLength[i];
            }
        }
        else {
            return;
        }
    }

    public void PowerBarOverTime(int i) {
        CurrPowerBar[i] += amountOverTime;
        PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
        if (CurrPowerBar[i] >= MaxPowerBar[i])
        {
            CurrPowerBar[i] = MaxPowerBar[i];
            GlowBar[i].Play();
        }
        else {
            GlowBar[i].Stop();
        }
    }

    public void ScoreCounter(int i)
    {
        skorPlayer[i]++;
        SkorText[i].text = " " + skorPlayer[i];
        penandaLastHitPlayer1[i] = false;
        penandaLastHitPlayer2[i] = false;
        SortScore();
        findHighestScore();
    }

    public void Respawning(int i)
    {
        if (!isRespawning[i])
        {
            StartCoroutine(RespawningCo(i));
        }
    }

    public void SortScore()
    {
        for (int i = 0; i < tempSkorPlayer.Length; i++) {
            tempSkorPlayer[i] = skorPlayer[i];
        }

        for (int i = 0; i < tempSkorPlayer.Length - 1; i++)
        {
            for (int j = i + 1; j < tempSkorPlayer.Length; j++)
            {
                if (tempSkorPlayer[i] < tempSkorPlayer[j]) {
                    int temp = tempSkorPlayer[i];
                    tempSkorPlayer[i] = tempSkorPlayer[j];
                    tempSkorPlayer[j] = temp;
                }
            }
        }
    }

    public void findHighestScore() {
        int c = 0;
        for (int i = 0; i < skorPlayer.Length; i++) {
            if (tempSkorPlayer[0] == skorPlayer[i])
            {
                playerCrown[i].enabled = true;
                c++;
            }
            else {
                playerCrown[i].enabled = false;
            }
        }
        if (c > 1) {
            for (int i = 0; i < playerCrown.Length; i++)
            {
                playerCrown[i].enabled = false;
            }
        }
    }

    public IEnumerator RespawningCo(int i)
    {
        isRespawning[i] = true;
        Player[i].SetActive(false);
        Player[i].transform.position = RespawnPoint[i].transform.position;
        yield return new WaitForSeconds(RespawnLength[i]);
        playerDeath[i]++;
        isRespawning[i] = false;
        Player[i].SetActive(true);
        CurrHealth[i] = MaxHealth[i];
        CurrPowerBar[i] = 0;
        HealthBar[i].text = "" + CurrHealth[i];
        PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
    }

    public IEnumerator DoubleDamage(int i) {
        amountDamage[i] *= 2;     
        yield return new WaitForSeconds(powerUpTime);
        amountDamage[i] /= 2;
        powerUpDamage[i] = false;
    }

    public IEnumerator DelayDamage(int i) {
        IsDamaged[i] = true;
        yield return new WaitForSeconds(0.5f);
        IsDamaged[i] = false;
    }
}
