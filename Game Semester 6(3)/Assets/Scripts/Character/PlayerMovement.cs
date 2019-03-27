﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    [Header("INPUT MANAGER")]
    public int ControlNumber;
    public InputManager IM;

    [Header("ISI PLAYER TAG")]
    public string PlayerTag;
    public GameObject Player;

    [Header("ISI PLAYERNUMBER --> 1/2/3/4")]
    public int PlayerNumber;
    public GameObject CharacterAttributesObject;
    public CharacterAttributes CharacterAttributes;

    public float MovementSpeed;
    public float SpeedMultiplier;

    public Vector3 PlayerPos;
    public Vector3 InputJoystick;

    public float Angle;
    public float TurnSpeed;
    public Quaternion TargetRotation;  

    // Use this for initialization
    void Start () {
        SpeedMultiplier = 1.0f;
        PlayerNumber = PlayerNumber - 1;
        IM = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        Player = GameObject.FindGameObjectWithTag(PlayerTag);

        CharacterAttributesObject = GameObject.FindGameObjectWithTag("CharacterAttributes");
        CharacterAttributes = CharacterAttributesObject.GetComponent<CharacterAttributes>();
    }
	
	// Update is called once per frame
	void Update () {
        GetWalkInput();
        if (Mathf.Abs(InputJoystick.x) > 0.1 || Mathf.Abs(InputJoystick.z) > 0.1)
        {
            Player.GetComponent<Animator>().SetBool("Running", true);
            CalculateDirection();
            Rotate();
            CheckPlayerPosition();
            PlayerMove();
        }
        else
        {
            Player.GetComponent<Animator>().SetBool("Running", false);
        }


    }

    public void GetWalkInput()
    {
        InputJoystick.x = Input.GetAxis(IM.HorizontalAxis[ControlNumber]);
        InputJoystick.z = Input.GetAxis(IM.VerticalAxis[ControlNumber]);
    }

    void CalculateDirection()
    {
        Angle = Mathf.Atan2(InputJoystick.x, InputJoystick.z);
        Angle = Mathf.Rad2Deg * Angle;
    }

    void Rotate()
    {
        TargetRotation = Quaternion.Euler(0, Angle, 0);
        Player.transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, TurnSpeed * Time.deltaTime);
    }

    void CheckPlayerPosition()
    {
        PlayerPos = Player.transform.position;
    }

    void PlayerMove()
    {

        Vector3 LeftJoystickInputDirection = Vector3.zero;

        LeftJoystickInputDirection.x = Input.GetAxis(IM.HorizontalAxis[ControlNumber]) * MovementSpeed * SpeedMultiplier;
        LeftJoystickInputDirection.z = Input.GetAxis(IM.VerticalAxis[ControlNumber]) * MovementSpeed * SpeedMultiplier;

        Player.transform.position = PlayerPos + LeftJoystickInputDirection;
    }
}
