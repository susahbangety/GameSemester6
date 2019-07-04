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

    public DartSpawn dart;
    public SpikeSpawn spike;
    // Start is called before the first frame update
    void Start()
    {
        SuddenDeathImage.SetActive(false);
        SuddenDeathClockImage.SetActive(false);
        TimeOutText.SetActive(false);
        countdownTimer();
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
            SuddenDeathImage.SetActive(true);

            StartCoroutine(HideText());
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
            timerText.color = Color.red;
            SuddenDeathClockImage.SetActive(true);
            ClockImage.SetActive(false);
            timerText.text = " " + spanTime.Seconds;
            startTimer--;
            Invoke("countdownTimer", 1.0f);
        }
        else
        {
            TimeOutText.SetActive(true);
        }
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2f);

        SuddenDeathImage.SetActive(false);
    }
}
