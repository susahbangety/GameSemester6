using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    [Header("INPUT MANAGER")]
    public int ControlNumber;
    public InputManager IM;

    [Header("ISI PLAYERNUMBER --> 1/2/3/4")]
    public int PlayerNumber;
    public CharacterAttributes CharacterAttributes;

    [Header("PLAYER WALK & JUMP")]
    private CharacterController charControl;
    public float verticalVelocity;
    public float gravity;
    public float jumpForce;

    public float MovementSpeed;
    public float SpeedMultiplier;

    public Vector3 PlayerPos;
    public Vector3 InputJoystick;

    public float Angle;
    public float TurnSpeed;
    public Quaternion TargetRotation;

    public bool Roll;
    public bool StartRoll;
    public float RollSpeed;
    public float RollTime;
    public float SetRollTime;

    public GameObject footStep;

    // Use this for initialization
    void Start () {
        SpeedMultiplier = 1.0f;
        PlayerNumber = PlayerNumber - 1;
        IM = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        charControl = GetComponent<CharacterController>();
        Roll = false;
    }
	
	// Update is called once per frame
	void Update () {
        playerWalkJump();
        if (Mathf.Abs(InputJoystick.x) > 0.1 || Mathf.Abs(InputJoystick.z) > 0.1)
        {
            gameObject.GetComponent<Animator>().SetBool("Running", true);
            if (charControl.isGrounded)
            {
                GameObject NewFootStep = Instantiate(footStep, transform.position, footStep.transform.rotation);
            }
            CalculateDirection();
            Rotate();
            CheckPlayerPosition();
            PlayerMove();
        }
        else if (Roll == true) {
            Rolling();
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Running", false);
        }

    }

    public void playerWalkJump()
    {
        if (charControl.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(IM.CircleButton[ControlNumber]))
            {
                verticalVelocity = jumpForce;
            }else if (Input.GetKeyDown(IM.LeftBumper[ControlNumber]) && Roll == false)
            {
                       gameObject.GetComponent<Animator>().SetBool("Rolling", true);
                       Roll = true;
                        StartRoll = true;
                        RollTime = 0;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        InputJoystick.x = Input.GetAxis(IM.HorizontalAxis[ControlNumber]);
        InputJoystick.z = Input.GetAxis(IM.VerticalAxis[ControlNumber]);
        charControl.Move(moveVector * Time.deltaTime);
    }

    //public void GetWalkInput()
    //{
    //    InputJoystick.x = Input.GetAxis(IM.HorizontalAxis[ControlNumber]);
    //    InputJoystick.z = Input.GetAxis(IM.VerticalAxis[ControlNumber]);
    //    if (Input.GetKeyDown(IM.CircleButton[ControlNumber]) && Roll == false) {
    //        gameObject.GetComponent<Animator>().SetBool("Rolling", true);
    //        Roll = true;
    //        StartRoll = true;
    //        RollTime = 0;
    //    }
    //}

    void Rolling()
    {
        if (StartRoll == true)
        {
            StartRoll = false;
        }

        RollSpeed = 0.1f;
        transform.position += transform.TransformDirection(Vector3.forward * RollSpeed);
        RollTime += Time.deltaTime;

        if (RollTime >= SetRollTime)
        {
            gameObject.GetComponent<Animator>().SetBool("Rolling", false);
            RollTime = SetRollTime;
            Roll = false;
        }
    }

    void CalculateDirection()
    {
        Angle = Mathf.Atan2(InputJoystick.x, InputJoystick.z);
        Angle = Mathf.Rad2Deg * Angle;
    }

    void Rotate()
    {
        TargetRotation = Quaternion.Euler(0, Angle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, TurnSpeed * Time.deltaTime);
    }

    void CheckPlayerPosition()
    {
        PlayerPos = transform.position;
    }

    void PlayerMove()
    {

        Vector3 LeftJoystickInputDirection = Vector3.zero;

        LeftJoystickInputDirection.x = Input.GetAxis(IM.HorizontalAxis[ControlNumber]) * MovementSpeed * SpeedMultiplier;
        LeftJoystickInputDirection.z = Input.GetAxis(IM.VerticalAxis[ControlNumber]) * MovementSpeed * SpeedMultiplier;

        transform.position = PlayerPos + LeftJoystickInputDirection;
    }
}
