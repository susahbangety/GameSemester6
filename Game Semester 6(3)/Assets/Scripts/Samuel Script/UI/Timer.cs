using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public int startTimer;
    public Text timerText;
    public GameObject ClockImage;
    public GameObject SuddenDeathClockImage;
    public GameObject SuddenDeathImage;
    public GameObject TimeOutText;
    public GameObject ScoreBoard;
    //public AudioSource SuddenDeathBGM;
    public float SlowDownFactor = 0.05f;
    public float SlowDownLength = 2f;

    public CharacterAttributes CA;
    public DartSpawn dart;
    public SpikeSpawn spike;
    // Start is called before the first frame update
    void Start()
    {
        SuddenDeathImage.SetActive(false);
        SuddenDeathClockImage.SetActive(false);
        TimeOutText.SetActive(false);
        countdownTimer();
        dart.enabled = false;
        spike.enabled = false;
        //dart = GameObject.Find("Dart").GetComponent<DartSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer < 240)
        {
            dart.enabled = true;
            spike.enabled = true;
        }
        if (startTimer == 58)
        {
            //SuddenDeathBGM.Play();
            SuddenDeathImage.SetActive(true);
            StartCoroutine(HideText());
            CA.amountOverTime *= 2;
            for(int i=0;i<spike.spikespawn.Count; i++)
            {
                spike.spikespawn[i].spawnChance = 50f;
            }
            for (int i = 0; i < dart.dartspawn.Count; i++)
            {
                dart.dartspawn[i].spawnChance = 75f;
            }
            spike.timeToSpawn = 15;
            dart.timeToSpawn = 15;
        }
    }

    void countdownTimer()
    {
        if (startTimer >= 60)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(startTimer);
            timerText.text = spanTime.Minutes + ":" + spanTime.Seconds;
            startTimer--;
            Invoke("countdownTimer", 1.0f);
        }
        else if (startTimer < 60 && startTimer > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(startTimer);
            timerText.text = " " + spanTime.Seconds;
            timerText.color = Color.red;
            SuddenDeathClockImage.SetActive(true);
            ClockImage.SetActive(false);
            
            startTimer--;
            Invoke("countdownTimer", 1.0f);
        }
        else
        {
            //Time.timeScale = 0f;
            TimeOutText.SetActive(true);
            //DoSlowMotion();
            StartCoroutine(HideText());
        }
    }

    void DoSlowMotion()
    {
        Time.timeScale = SlowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(3f);

        SuddenDeathImage.SetActive(false);
        TimeOutText.SetActive(false);
    }
}
