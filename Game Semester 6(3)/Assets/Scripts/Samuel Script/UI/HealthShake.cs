using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShake : MonoBehaviour
{
    //public float Power;
    //public float Duration;
    //public Transform healthText;
    //public float slowDownAmount;
    //public bool shouldShake = false;

    //Vector3 startPosition;
    //float initialDuration;

    //void Start()
    //{
    //    healthText =     
    //}

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public RectTransform HealthTransform;

    // How long the object should shake for.
    public float shakeDuration = 0.5f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (HealthTransform == null)
        {
            HealthTransform = GetComponent(typeof(RectTransform)) as RectTransform;
        }
    }

    void OnEnable()
    {
        originalPos = HealthTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            HealthTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            HealthTransform.localPosition = originalPos;
        }
    }
}
