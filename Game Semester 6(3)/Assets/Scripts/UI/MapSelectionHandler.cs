using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelectionHandler : MonoBehaviour
{
    [Header("Buat Inputan")]
    public InputManager IM;
    public int ControlNumber;


    public Image[] ImageSelected;
    public int index;
    public int maxIndex;
    public Vector3 inputAxis;

    public bool inputHold;
    public Image StartSelected;
    public bool IsSelected;
    public int pilihanMap;

    // Start is called before the first frame update
    void Start()
    {
        StartSelected.enabled = false;
        index = 0;
        maxIndex = ImageSelected.Length - 1;
        ApplyInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSelected == false)
        {
            GetInputAxis();
            if (inputAxis.z > 0.2f || inputAxis.z < -0.2f)
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
        else
        {
            VerifyScene();
        }
    }

    void PindahInput()
    {
        if (inputAxis.z < -0.2f)
        {
            if (index < maxIndex)
            {
                index++;
            }
        }
        if (inputAxis.z > 0.2f)
        {
            if (index > 0)
            {
                index--;
            }
        }

    }

    void GetInputAxis(){
        inputAxis.z = Input.GetAxis(IM.VerticalAxis[ControlNumber]);
    }

    void ApplyInput() {
        for (int i = 0; i <= maxIndex; i++) {
            ImageSelected[i].enabled = false;
        }
        ImageSelected[index].enabled = true;
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
            Debug.Log("Berhasil memilih japan");
            IsSelected = true;
            StartSelected.enabled = true;
            pilihanMap = 1;
         
        }
        if (index == 1 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
        {
            Debug.Log("Berhasil memilih medieval");
            IsSelected = true;
            StartSelected.enabled = true;
            pilihanMap = 2;
        }
        if (index == 2 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
        {
            Debug.Log("Berhasil memilih pirate");
            IsSelected = true;
            StartSelected.enabled = true;
            pilihanMap = 3;

        }
        if (index == 3 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
        {
            Debug.Log("Berhasil memilih random");
            IsSelected = true;
            StartSelected.enabled = true;
            pilihanMap = 4;
        }
    }

    void VerifyScene()
    {
        if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && pilihanMap == 1)
        {
            SceneManager.LoadScene("InGame");
        }
        else if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && pilihanMap == 2)
        {
            SceneManager.LoadScene("InGame");
        }
        else if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && pilihanMap == 3)
        {
            SceneManager.LoadScene("InGame");
        }
        else if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && pilihanMap == 4)
        {
            SceneManager.LoadScene("InGame");
        }
    }
}
