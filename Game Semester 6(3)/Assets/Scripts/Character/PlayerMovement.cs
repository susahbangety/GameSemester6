using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [Header("INPUT MANAGER")]
    public int ControlNumber;
    public InputManager IM;

    [Header("ISI PLAYERNUMBER --> 1/2/3/4")]
    public int PlayerNumber;
    public CharacterAttributes CharacterAttributes;

    [Header("WALK & JUMP")]
    private CharacterController charControl;
    public float verticalVelocity;
    public float gravity;
    public float jumpForce;

    [Header("ROLLING")]
    public bool Roll;
    public bool StartRoll;
    public float RollSpeed;
    public float RollTime;
    public float SetRollTime;

    public bool isStun;
    public float StunTime;

    public float MovementSpeed;
    public float SpeedMultiplier;

    public Vector3 PlayerPos;
    public Vector3 InputJoystick;

    public float Angle;
    public float TurnSpeed;
    public Quaternion TargetRotation;



    public GameObject footStep;

    // Use this for initialization
    void Start()
    {
        SpeedMultiplier = 1.0f;
        PlayerNumber = PlayerNumber - 1;
        IM = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        charControl = GetComponent<CharacterController>();
        Roll = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerWalkJump();
        if (Mathf.Abs(InputJoystick.x) < 0.1 && Mathf.Abs(InputJoystick.z) < 0.1 && Roll == false)
        {
            gameObject.GetComponent<Animator>().SetBool("Running", false);
            return;
        }
        if (Roll == true)
        {
            Rolling();
        }
        if (Roll == false)
        {
            if (charControl.isGrounded)
            {
                GameObject NewFootStep = Instantiate(footStep, transform.position, footStep.transform.rotation);
            }
            gameObject.GetComponent<Animator>().SetBool("Running", true);
            Rotate();
            CalculateDirection();
            CheckPlayerPosition();
            PlayerMove();
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
                gameObject.GetComponent<Animator>().SetTrigger("Jump");
            }
            if (Input.GetKeyDown(IM.LeftBumper[ControlNumber]) && Roll == false)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Roll");
                //Roll = true;
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

        transform.position += transform.forward * RollSpeed;
        //transform.position += transform.TransformDirection(Vector3.forward * RollSpeed);
        //RollSpeed = 0.1f;
        //RollTime += Time.deltaTime;

        //if (RollTime >= SetRollTime)
        //{
        //    gameObject.GetComponent<Animator>().SetBool("Rolling", false);
        //    RollTime = SetRollTime;
        //    Roll = false;
        //}
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

    public void PlayerStun()
    {
        if (isStun)
        {
            return;
        }

        isStun = true;
        this.enabled = false;
        gameObject.GetComponent<Animator>().SetBool("Running", false);

        StartCoroutine(WaitForStunToEnd());
    }

    private IEnumerator WaitForStunToEnd()
    {
        yield return new WaitForSeconds(StunTime);
        isStun = false;
        this.enabled = true;
        gameObject.GetComponent<Animator>().SetBool("Running", true);
    }
}
