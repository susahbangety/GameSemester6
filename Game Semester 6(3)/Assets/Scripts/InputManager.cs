﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public string[] HorizontalAxis = new string[4];
    public string[] VerticalAxis = new string[4];

    public KeyCode[] XButton = new KeyCode[4];
    public KeyCode[] CircleButton = new KeyCode[4];
    public KeyCode[] SquareButton = new KeyCode[4];
    public KeyCode[] TriangleButton = new KeyCode[4];
    public KeyCode[] StartButton = new KeyCode[4];

    // Use this for initialization
    void Start () {
        XButton[0] = KeyCode.Joystick1Button0;
        XButton[1] = KeyCode.Joystick2Button0;
        XButton[2] = KeyCode.Joystick3Button0;
        XButton[3] = KeyCode.Joystick4Button0;

        CircleButton[0] = KeyCode.Joystick1Button1;
        CircleButton[1] = KeyCode.Joystick2Button1;
        CircleButton[2] = KeyCode.Joystick3Button1;
        CircleButton[3] = KeyCode.Joystick4Button1;

        SquareButton[0] = KeyCode.Joystick1Button2;
        SquareButton[1] = KeyCode.Joystick2Button2;
        SquareButton[2] = KeyCode.Joystick3Button2;
        SquareButton[3] = KeyCode.Joystick4Button2;

        TriangleButton[0] = KeyCode.Joystick1Button3;
        TriangleButton[1] = KeyCode.Joystick2Button3;
        TriangleButton[2] = KeyCode.Joystick3Button3;
        TriangleButton[3] = KeyCode.Joystick4Button3;

        StartButton[0] = KeyCode.Joystick1Button7;
        StartButton[1] = KeyCode.Joystick2Button7;
        StartButton[2] = KeyCode.Joystick3Button7;
        StartButton[3] = KeyCode.Joystick4Button7;

        HorizontalAxis[0] = "LeftJoystick1Horizontal";
        HorizontalAxis[1] = "LeftJoystick2Horizontal";
        HorizontalAxis[2] = "LeftJoystick3Horizontal";
        HorizontalAxis[3] = "LeftJoystick4Horizontal";

        VerticalAxis[0] = "LeftJoystick1Vertical";
        VerticalAxis[1] = "LeftJoystick2Vertical";
        VerticalAxis[2] = "LeftJoystick3Vertical";
        VerticalAxis[3] = "LeftJoystick4Vertical";
    }	
}
