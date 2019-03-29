using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectionHandler : MonoBehaviour
{
    [Header("Buat Inputan")]
    public InputManager IM;
    public int ControlNumber;

    public Image[] ImageBorder;
    public Image[] Checklist;
    public Image NextSelected;

    public int index;
    public int maxIndex;

    public bool inputHold;
    public Vector3 inputAxis;

    public int BanyakPlayer;
    public bool IsSelected;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Checklist.Length; i++) {
            Checklist[i].enabled = false;
        }
        IsSelected = false;
        index = 0;
        BanyakPlayer = 0;
        maxIndex = ImageBorder.Length - 1;
        inputHold = false;
        NextSelected.enabled = false;
        ApplyInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSelected == false)
        {
            GetInputAxis();
            if (inputAxis.x > 0.2f || inputAxis.x < -0.2f)
            {
                if (inputHold == false)
                {
                    PindahInput();
                    ApplyInput();
                    StartCoroutine(InputHolder());
                }
            }
            CheckInput();
        }
        else {
            VerifyPlayer();
        }

    }

    void GetInputAxis()
    {
        inputAxis.x = Input.GetAxis(IM.HorizontalAxis[ControlNumber]);
    }


    void PindahInput()
    {
        if (inputAxis.x > -0.2f)
        {
            if (index < maxIndex)
            {
                index++;
            }
        }
        if (inputAxis.x < 0.2f)
        {
            if (index > 0)
            {
                index--;
            }
        }

    }

    void ApplyInput()
    {
        for (int i = 0; i <= maxIndex; i++)
        {
            ImageBorder[i].enabled = false;
        }
        ImageBorder[index].enabled = true;
    }


    IEnumerator InputHolder()
    {
        inputHold = true;
        yield return new WaitForSeconds(0.4f);
        inputHold = false;
    }

    void CheckInput()
    {
        if (index == 0 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
        {
            Debug.Log("Berhasil memilih 2 player");
            BanyakPlayer = 2;
            IsSelected = true;
            Checklist[index].enabled = true;
            NextSelected.enabled = true;
            SceneManager.LoadScene("MapSelection");
        }
        if (index == 1 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
        {
            Debug.Log("Berhasil memilih 3 player");
            BanyakPlayer = 3;
            IsSelected = true;
            Checklist[index].enabled = true;
            SceneManager.LoadScene("MapSelection");

        }
        if (index == 2 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
        {
            Debug.Log("Berhasil memilih 4 player");
            BanyakPlayer = 4;
            IsSelected = true;
            Checklist[index].enabled = true;
            NextSelected.enabled = true;
            SceneManager.LoadScene("MapSelection");
        }
    }

    void VerifyPlayer() {
        if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && BanyakPlayer == 2) {
            Debug.Log("Berhasil masuk ke scene 2 player");
        }
        else if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && BanyakPlayer == 3)
        {
            Debug.Log("Berhasil masuk ke scene 3 player");
        }
        else if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && BanyakPlayer == 4)
        {
            Debug.Log("Berhasil masuk ke scene 4 player");
        }
    }
}
