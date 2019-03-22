using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetControllerNumber : MonoBehaviour {

    public GameObject[] Player = new GameObject[4];
    public ControllerNumber CN;
    public int[] ControlNumber = new int[4];


	// Use this for initialization
	void Start () {

        CN = GameObject.Find("ControlNumber").GetComponent<ControllerNumber>();

        for (int i = 0; i < ControlNumber.Length; i++) {
            ControlNumber[i] = CN.ControlNumber[i];
        }
        Player[0] = GameObject.FindGameObjectWithTag("Player");
        Player[1] = GameObject.FindGameObjectWithTag("Player2");
        Player[2] = GameObject.FindGameObjectWithTag("Player3");
        Player[3] = GameObject.FindGameObjectWithTag("Player4");
	}
}
