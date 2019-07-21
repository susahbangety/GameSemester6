using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttributes : MonoBehaviour {

    public GameObject[] Player;
    public SkinnedMeshRenderer[] PlayerRenderer;

    [Header("Darah dan PowerBar")]
    public float[] CurrHealth;
    public float[] MaxHealth;
    public float[] CurrPowerBar;
    public float[] MaxPowerBar;

    [Header("Invicibility")]
    public float[] InvicibilityLength;
    public float[] InvicibilityCounter;
    public float[] FlashCounter;
    public float[] FlashLength;

    [Header("Besaran Damage dan PowerBar")]
    public float[] amountPowerBar;
    public float[] amountDamage;
    public float[] TotalDamage;

    [Header("UI")]
    public float SetMaxHP;
    public float SetMaxPowerBar;
    public Text[] HealthBar;
    public Image[] PowerBar;
    public Image[] DoubleDamageIcon;
    public ParticleSystem[] GlowBar;
    public HealthShake[] HealthShakeEffect;
    public Text[] SkorText;
    public int[] skorPlayer;
    public int[] tempSkorPlayer;
    public Image[] playerCrown;

    [Header("Respawn")]
    public float[] RespawnLength;
    public bool[] isRespawning;
    public Transform[] RespawnPoint;
    //public GameObject RespawnEffect;

    [Header("Kumpulan boolean")]
    public bool[] IsUltiReady;
    public bool[] isHit;
    public bool[] IsDamaged;
    
    [Header("Besaran powerbar yang bertambah setiap detik")]
    public float amountOverTime;

    [Header("Waktu lifetime powerup")]
    public float powerUpTime;
    public bool[] powerUpDamage;
    public float[] DamageMultiplier;

    [Header("Untuk menghitung jumlah mati setiap player")]
    public int[] playerDeath;

    // Use this for initialization
    void Start() {
        CurrHealth = new float[Player.Length];
        MaxHealth = new float[Player.Length];
        CurrPowerBar = new float[Player.Length];
        MaxPowerBar = new float[Player.Length];
        isRespawning = new bool[Player.Length];
        IsDamaged = new bool[Player.Length];
        //RespawnLength = new float[Player.Length];
        IsUltiReady = new bool[Player.Length];
        amountPowerBar = new float[Player.Length];
        amountDamage = new float[Player.Length];
        DamageMultiplier = new float[Player.Length];
        TotalDamage = new float[Player.Length];
   

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
            DamageMultiplier[i] = 1;
            DoubleDamageIcon[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < Player.Length; i++) {
            PowerBarOverTime(i);

            if (CurrPowerBar[i] == SetMaxPowerBar) {
                IsUltiReady[i] = true;
            }
            if (isHit[i] == true) {
                AttackSuccess(i);
            }

            if (powerUpDamage[i] == true) {
                DoubleDamageIcon[i].enabled = true;
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
        if (Player[i].GetComponent<PlayerAttack>().lagiUlti[i] == false) {
            CurrPowerBar[i] += amountPowerBar[i];
            PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
            isHit[i] = false;
            if (CurrPowerBar[i] >= MaxPowerBar[i])
            {
                CurrPowerBar[i] = MaxPowerBar[i];
            }
        }
    }

    public void CalculateHealth(int i, int j) {
        if (IsDamaged[i] == false)
        {
            TotalDamage[j] = amountDamage[j] * DamageMultiplier[j];
            if (CurrHealth[i] <= TotalDamage[j])
            {
                ScoreCounter(j);
            }
            CurrHealth[i] -= TotalDamage[j];
            HealthShakeEffect[i].enabled = true;
            StartCoroutine(DelayDamage(i));
            StartCoroutine(HealthShakeAgain(i));
            HealthBar[i].text = "" + CurrHealth[i];
            if (CurrHealth[i] <= 0)
            {
                Respawning(i);
                InvicibilityCounter[i] = InvicibilityLength[i];
                HealthShakeEffect[i].enabled = false;
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
        HealthBar[i].text = "0";
        Player[i].SetActive(false);
        Player[i].transform.position = RespawnPoint[i].transform.position;
        //Instantiate(RespawnEffect, RespawnPoint[i].transform.position, RespawnPoint[i].transform.rotation);
        yield return new WaitForSeconds(RespawnLength[i]);
        playerDeath[i]++;
        isRespawning[i] = false;
        Player[i].SetActive(true);
        CurrHealth[i] = MaxHealth[i];
        CurrPowerBar[i] = 0;
        HealthBar[i].text = "" + CurrHealth[i];
        PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
        Player[i].GetComponent<EquipWeapon>().weaponActive = false;
        Player[i].GetComponent<EquipWeapon>().Axe.SetActive(false);
        Player[i].GetComponent<EquipWeapon>().Sword.SetActive(false);
        Player[i].GetComponent<EquipWeapon>().Spear.SetActive(false);
        Player[i].GetComponent<EquipWeapon>().Hammer.SetActive(false);
        Player[i].GetComponent<EquipWeapon>().Knife.SetActive(false);
        Player[i].GetComponent<PlayerAttack>().HaveWeapon = false;
        Player[i].GetComponent<PlayerAttack>().HaveWeaponAxe = false;
        Player[i].GetComponent<PlayerAttack>().HaveWeaponSword = false;
        Player[i].GetComponent<PlayerAttack>().HaveWeaponSpear = false;
        Player[i].GetComponent<PlayerAttack>().HaveWeaponHammer = false;
        Player[i].GetComponent<PlayerAttack>().HaveWeaponKnife = false;
    }

    public IEnumerator DoubleDamage(int i) {
        DamageMultiplier[i] += 1;
        powerUpDamage[i] = false;
        //DoubleDamageIcon[i].GetComponent<BlinkImage>().timerAlpha += Time.deltaTime;
        yield return new WaitForSeconds(powerUpTime);
        DoubleDamageIcon[i].enabled = false;
        DamageMultiplier[i] -= 1;

    }

    public IEnumerator DelayDamage(int i) {
        IsDamaged[i] = true;
        yield return new WaitForSeconds(0.5f);
        IsDamaged[i] = false;
    }

    IEnumerator HealthShakeAgain(int i)
    {
        yield return new WaitForSeconds(0f);

        HealthShakeEffect[i].shakeDuration = 0.5f;
        //HealthShakeEffect[i].enabled = false;
    }
}
