using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionHandler : MonoBehaviour
{
    [Header("Buat Inputan")]
    public InputManager IM;
    public int ControlNumber;

    public Image[] pilihanOption;
    public Image[] pilihanOpsi;
    public bool[] isSelected;
    public int[] index;
    public int[] maxIndex;

    public bool inputHold;
    public Vector3 inputAxis;

    // Start is called before the first frame update
    void Start()
    {
        maxIndex[0] = pilihanOption.Length - 1;
        maxIndex[1] = pilihanOpsi.Length - 1;
        ApplyInputKebawah();
        ApplyInputKeSamping();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputAxisHorizontal();
        GetInputAxisVertical();
        if (inputAxis.z > 0.2f || inputAxis.z < -0.2f)
        {
            if (inputHold == false)
            {
                PindahInputKebawah();
                ApplyInputKebawah();
                StartCoroutine(InputHolder());
            }
        }
    }

    void GetInputAxisHorizontal()
    {
        inputAxis.x = Input.GetAxis(IM.HorizontalAxis[ControlNumber]);
    }

    void GetInputAxisVertical()
    {
        inputAxis.z = Input.GetAxis(IM.VerticalAxis[ControlNumber]);
    }

    void PindahInputKebawah()
    {
        if (inputAxis.z < -0.2f)
        {
            if (index[0] < maxIndex[0])
            {
                index[0]++;
            }
        }
        if (inputAxis.z > 0.2f)
        {
            if (index[0] > 0)
            {
                index[0]--;
            }
        }
    }

    void PindahInputKeSamping()
    {
        if (inputAxis.x > -0.2f)
        {
            if (index[1] < maxIndex[1])
            {
                index[1]++;
            }
        }
        if (inputAxis.x < 0.2f)
        {
            if (index[1] > 0)
            {
                index[1]--;
            }
        }
    }

    void ApplyInputKebawah()
    {
        for (int i = 0; i <= maxIndex[0]; i++)
        {
            pilihanOption[i].enabled = false;
        }
        pilihanOption[index[0]].enabled = true;
    }

    void ApplyInputKeSamping()
    {
        for (int i = 0; i <= maxIndex[1]; i++)
        {
            pilihanOpsi[i].enabled = false;
        }
        pilihanOpsi[index[1]].enabled = true;
    }


    IEnumerator InputHolder()
    {
        inputHold = true;
        yield return new WaitForSeconds(0.4f);
        inputHold = false;
    }

    //void CheckInput()
    //{
    //    if (index == 0 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
    //    {
    //        Debug.Log("Berhasil memilih 2 player");
    //        BanyakPlayer = 2;
    //        IsSelected = true;
    //        Checklist[index].enabled = true;
    //        NextSelected.enabled = true;
    //        //SceneManager.LoadScene("InGame");
    //    }
    //    if (index == 1 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
    //    {
    //        Debug.Log("Berhasil memilih 3 player");
    //        BanyakPlayer = 3;
    //        IsSelected = true;
    //        Checklist[index].enabled = true;
    //        NextSelected.enabled = true;
    //        //SceneManager.LoadScene("Option");
    //    }
    //    if (index == 2 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
    //    {
    //        Debug.Log("Berhasil memilih 4 player");
    //        BanyakPlayer = 4;
    //        IsSelected = true;
    //        Checklist[index].enabled = true;
    //        NextSelected.enabled = true;
    //        //SceneManager.LoadScene("Credit");
    //    }
    //}

    //void VerifyPlayer()
    //{
    //    if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && BanyakPlayer == 2)
    //    {
    //        Debug.Log("Berhasil masuk ke scene 2 player");
    //    }
    //    else if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && BanyakPlayer == 3)
    //    {
    //        Debug.Log("Berhasil masuk ke scene 3 player");
    //    }
    //    else if (Input.GetKeyDown(IM.StartButton[ControlNumber]) && BanyakPlayer == 4)
    //    {
    //        Debug.Log("Berhasil masuk ke scene 4 player");
    //    }
    //}
}
