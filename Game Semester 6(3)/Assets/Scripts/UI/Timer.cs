using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public int startTimer;
    public Text timerText;

    public DartSpawn dart;
    // Start is called before the first frame update
    void Start()
    {
        countdownTimer();
        //dart = GameObject.Find("Dart").GetComponent<DartSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer < 240)
        {
            dart.enabled = true;
        }
    }

    void countdownTimer()
    {
        if (startTimer >= 60)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(startTimer);
            timerText.text = spanTime.Minutes + " : " + spanTime.Seconds;
            startTimer--;
            Invoke("countdownTimer", 1.0f);
        }
        else if (startTimer < 60 && startTimer > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(startTimer);
            timerText.text = " " + spanTime.Seconds;
            startTimer--;
            Invoke("countdownTimer", 1.0f);
        }
        else
        {
            timerText.text = "Time Out!";
            timerText.rectTransform.anchorMin = new Vector2(0.5f, 0.65f);
            timerText.rectTransform.anchorMax = new Vector2(0.5f, 0.65f);
            timerText.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        }
    }
}
