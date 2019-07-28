using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    [Header("INPUT MANAGER")]
    public int ControlNumber;
    public InputManager IM;
    public PlayerAttack pa;

    [Header("ISI PLAYERNUMBER --> 1/2/3/4")]
    public int PlayerNumber;
    public CharacterAttributes ca;

    [Header("WALK & JUMP")]
    private CharacterController charControl;
    public float verticalVelocity;
    public float gravity;
    public float jumpForce;

    [Header("ROLLING")]
    public bool Roll;
    public bool StartRoll;
    public bool RollReady;
    public float RollSpeed;
    public float RollTime;
    public float RollDelayTime;
    public Image TandaRoll;
    public AudioSource RollSound;

    [Header("Attribute")]
    public float MovementSpeed;
    public float SpeedMultiplier;
    public Vector3 PlayerPos;
    public Vector3 InputJoystick;
    public float Angle;
    public float TurnSpeed;
    public Quaternion TargetRotation;
    
    public GameObject footStep;

    [Header("STUNNED")]
    public bool isStun;
    public float StunTime;
    public GameObject stunnedEffect;

    // Use this for initialization
    void Start()
    {
        TandaRoll.enabled = false;
        SpeedMultiplier = 1.0f;
        PlayerNumber = PlayerNumber - 1;
        IM = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        charControl = GetComponent<CharacterController>();
        Roll = false;
        RollReady = true;
        stunnedEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pa.lagiUlti[ControlNumber] == false && ca.isRespawning[ControlNumber] == false && ca.InvicibleState[ControlNumber] == false) {
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
    }

    public void playerWalkJump()
    {
        if (charControl.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(IM.AButton[ControlNumber]))
            {
                verticalVelocity = jumpForce;
                gameObject.GetComponent<Animator>().SetTrigger("Jump");
  
            }
            if (Input.GetKeyDown(IM.LeftBumper[ControlNumber]) && Roll == false && RollReady == true)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Roll");
                RollSound.Play();
                StartRoll = true;
                RollTime = 0;
                StartCoroutine(RollDelay());
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

    void Rolling()
    {
        if (StartRoll == true)
        {
            StartRoll = false;
        }
        transform.position += transform.forward * RollSpeed;
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
        stunnedEffect.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("Running", false);
        //gameObject.GetComponent<PlayerAttack>().AttackState = false;
        StartCoroutine(WaitForStunToEnd());
    }

    public void PlayerSlow()
    {
        MovementSpeed /= 2;

        StartCoroutine(BackFromSlow());
    }

    IEnumerator RollDelay() {
        TandaRoll.enabled = true;
        RollReady = false;
        yield return new WaitForSeconds(RollDelayTime);
        RollReady = true;
        TandaRoll.enabled = false;
    }

    private IEnumerator WaitForStunToEnd()
    {
        yield return new WaitForSeconds(StunTime);
        isStun = false;
        this.enabled = true;
        stunnedEffect.SetActive(false);
        //gameObject.GetComponent<PlayerAttack>().AttackState = true;
        gameObject.GetComponent<Animator>().SetBool("Running", true);
    }

    IEnumerator BackFromSlow()
    { 
        yield return new WaitForSeconds(2f);

        MovementSpeed *= 2;
    }
}
