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
    public Vector3[] RespawnPoint;


    // Use this for initialization
    void Start () {
        CurrHealth = new float[Player.Length];
        MaxHealth = new float[Player.Length];
        CurrPowerBar = new float[Player.Length];
        MaxPowerBar = new float[Player.Length];
        IsDamaged = new bool[Player.Length];
        InvicibilityCounter = new float[Player.Length];
        InvicibilityLength = new float[Player.Length];
        FlashCounter = new float[Player.Length];
        FlashLength = new float[Player.Length];
        isRespawning = new bool[Player.Length];
        RespawnPoint = new Vector3[Player.Length];
        RespawnLength = new float[Player.Length];

        for (int i = 0; i < Player.Length; i++)
        {
            MaxHealth[i] = SetMaxHP;
            CurrHealth[i] = MaxHealth[i];
            MaxPowerBar[i] = SetMaxPowerBar;
        }
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Player.Length; i++) {
            if (IsDamaged[i] == true) {
                CalculateHealth(i);
            }
            if (InvicibilityCounter[i] > 0)
            {
                InvicibilityCounter[i] -= Time.deltaTime;
                FlashCounter[i] -= Time.deltaTime;
                if (FlashCounter[i] <= 0)
                {
                    PlayerRenderer[i].enabled = !PlayerRenderer[i].enabled;
                    FlashCounter[i] = FlashLength[i];
                }
                if (InvicibilityCounter[i] <= 0)
                {
                    PlayerRenderer[i].enabled = true;
                }
            }
        }
    }

    public void AttackSuccess(int i) {
        CurrPowerBar[i] += amount;
        PowerBar[i].fillAmount = CurrPowerBar[i] / MaxPowerBar[i];
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
        }
    }

    public void Respawning(int i)
    {
        if (!isRespawning[i])
        {
            StartCoroutine(RespawningCo(i));
        }
    }

    void Damaged(Vector2 info)
    {
        CurrHealth[(int)info.x] -= info.y;
        IsDamaged[(int)info.x] = true;
        //Debug.Log(IsDamaged[(int)info.x]);
    }

    public IEnumerator RespawningCo(int i)
    {
        isRespawning[i] = true;
        Player[i].SetActive(false);
        Player[i].transform.position = RespawnPoint[i];
        yield return new WaitForSeconds(RespawnLength[i]);
        isRespawning[i] = false;
        Player[i].SetActive(true);
        CurrHealth[i] = MaxHealth[i];
        HealthBar[i].fillAmount = CurrHealth[i] / MaxHealth[i];
        InvicibilityCounter[i] = InvicibilityLength[i];
    }
}
