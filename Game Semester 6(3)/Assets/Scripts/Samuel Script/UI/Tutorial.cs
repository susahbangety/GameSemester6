using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Canvas canvasTutor;
    public int ControlNumber;
    public AudioSource BGM;

    public InputManager IM;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        BGM.Stop();
        canvasTutor.enabled = true;
        //StartCoroutine(KeluarinTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(IM.StartButton[ControlNumber]))
        {
            canvasTutor.enabled = false;
            BGM.Play();
            Time.timeScale = 1f;
        }
    }
}
