using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerNumber : MonoBehaviour {

    [Header("INPUT NOMOR CONTROLLER 1-6 dari player 1-4")]
    public int[] ControlNumber = new int[4];

    private void Awake()
    {
        for (int i = 0; i < ControlNumber.Length; i++)
            ControlNumber[i] = ControlNumber[i] - 1;
    }
}
