using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public string[] HorizontalAxis = new string[4];
    public string[] VerticalAxis = new string[4];

    public KeyCode[] AButton = new KeyCode[4];
    public KeyCode[] BButton = new KeyCode[4];
    public KeyCode[] XButton = new KeyCode[4];
    public KeyCode[] YButton = new KeyCode[4];
    public KeyCode[] StartButton = new KeyCode[4];
    public KeyCode[] LeftBumper = new KeyCode[4];


    // Use this for initialization
    void Start () {
        AButton[0] = KeyCode.Joystick1Button0;
        AButton[1] = KeyCode.Joystick2Button0;
        AButton[2] = KeyCode.Joystick3Button0;
        AButton[3] = KeyCode.Joystick4Button0;

        BButton[0] = KeyCode.Joystick1Button1;
        BButton[1] = KeyCode.Joystick2Button1;
        BButton[2] = KeyCode.Joystick3Button1;
        BButton[3] = KeyCode.Joystick4Button1;

        XButton[0] = KeyCode.Joystick1Button2;
        XButton[1] = KeyCode.Joystick2Button2;
        XButton[2] = KeyCode.Joystick3Button2;
        XButton[3] = KeyCode.Joystick4Button2;

        YButton[0] = KeyCode.Joystick1Button3;
        YButton[1] = KeyCode.Joystick2Button3;
        YButton[2] = KeyCode.Joystick3Button3;
        YButton[3] = KeyCode.Joystick4Button3;

        LeftBumper[0] = KeyCode.Joystick1Button4;
        LeftBumper[1] = KeyCode.Joystick2Button4;
        LeftBumper[2] = KeyCode.Joystick3Button4;
        LeftBumper[3] = KeyCode.Joystick4Button4;

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
