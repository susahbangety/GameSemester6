using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BlinkImage : MonoBehaviour
{
    public float minAlpha = 0.1f; // The minimum value of the alpha channel, from 0.
    public float maxAlpha = 0.9f; // The maximum value of the alpha channel, up to 1.
    public float timerAlpha = 100f; // The conditional time for changing the magnitude of the alpha channel value.

    private float minAlphaZ;
    private float maxAlphaZ;
    private float timerAlphaZ;
    private float alphazxc;
    private bool timertr = false;
    private Color rezcolor;

    void Start()
    {
        alphazxc = minAlpha;
        minAlphaZ = minAlpha;
        maxAlphaZ = maxAlpha;
        timerAlphaZ = timerAlpha / 100.0f; // The conditional time.
        rezcolor = this.GetComponent<SpriteRenderer>().color; // The current value of the color of the text.
    }

    //private void Update()
    //{
    //    timerAlpha += Time.deltaTime;
    //    Debug.Log(timerAlpha);
    //}

    private void FixedUpdate()
    {
        if (timertr == false) // Increase the minimum value of the alpha channel, to the maximum.
        {
            minAlphaZ += timerAlphaZ * Time.deltaTime;
            alphazxc = minAlphaZ;
            if (minAlphaZ >= maxAlpha)
            {
                timertr = true;
                minAlphaZ = minAlpha;
            }
        }

        if (timertr == true) // Decrease the maximum value of the alpha channel, to the minimum.
        {
            maxAlphaZ -= timerAlphaZ * Time.deltaTime;
            alphazxc = maxAlphaZ;
            if (maxAlphaZ <= minAlpha)
            {
                timertr = false;
                maxAlphaZ = maxAlpha;
            }
        }
        this.GetComponent<SpriteRenderer>().color = new Color(rezcolor.r, rezcolor.g, rezcolor.b, alphazxc);
    }
}
