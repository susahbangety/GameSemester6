using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionHandler : MonoBehaviour
{
    [Header("Buat Inputan")]
    public InputManager IM;
    public int ControlNumber;

    public Image[] pilihanOption;
    public Image[] pilihanOpsiMusic;
    public Image[] pilihanOpsiEffect;
    public Image[] pilihanOpsiScreen;
    public bool[] isSelected;
    public int[] index;
    public int[] maxIndex;

    public bool inputHold, inputHold2;
    public Vector3 inputAxis;

    // Start is called before the first frame update
    void Start()
    {
        maxIndex[0] = pilihanOption.Length - 1;
        maxIndex[1] = pilihanOpsiMusic.Length - 1;
        maxIndex[2] = pilihanOpsiEffect.Length - 1;
        maxIndex[3] = pilihanOpsiScreen.Length - 1;
        ApplyInputKebawah();
        ApplyInputKeSampingMusic();
        ApplyInputKeSampingEffect();
        ApplyInputKeSampingScreen();
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
        VerifyInput();
        CheckOnOff();
        ApplySetting();
    }

    void CheckOnOff() {
        if (index[1] == 0) {
            Debug.Log("music turn on");
        }
        if (index[1] == 1) {
            Debug.Log("music turn off");
        }
        if (index[2] == 0)
        {
            Debug.Log("effect turn on");
        }
        if (index[2] == 1)
        {
            Debug.Log("effect turn off");
        }
        if (index[3] == 0)
        {
            Debug.Log("screen fullscreen");
        }
        if (index[3] == 1)
        {
            Debug.Log("screen windowed");
        }
    }

    void VerifyInput() {
        if (index[0] == 0)
        {
            if (inputAxis.x > 0.2f || inputAxis.x < -0.2f) {
                PindahInputKeSampingMusic();
                ApplyInputKeSampingMusic();
                StartCoroutine(InputHolder2());
            }
        }
        if (index[0] == 1)
        {
            if (inputAxis.x > 0.2f || inputAxis.x < -0.2f)
            {
                PindahInputKeSampingEffect();
                ApplyInputKeSampingEffect();
                StartCoroutine(InputHolder2());

            }
        }
        if (index[0] == 2)
        {
            if (inputAxis.x > 0.2f || inputAxis.x < -0.2f)
            {
                PindahInputKeSampingScreen();
                ApplyInputKeSampingScreen();
                StartCoroutine(InputHolder2());
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

    void PindahInputKeSampingMusic()
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

    void PindahInputKeSampingEffect()
    {
        if (inputAxis.x > -0.2f)
        {
            if (index[2] < maxIndex[2])
            {
                index[2]++;
            }
        }
        if (inputAxis.x < 0.2f)
        {
            if (index[2] > 0)
            {
                index[2]--;
            }
        }
    }

    void PindahInputKeSampingScreen()
    {
        if (inputAxis.x > -0.2f)
        {
            if (index[3] < maxIndex[3])
            {
                index[3]++;
            }
        }
        if (inputAxis.x < 0.2f)
        {
            if (index[3] > 0)
            {
                index[3]--;
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

    void ApplyInputKeSampingMusic()
    {
        for (int i = 0; i <= maxIndex[1]; i++)
        {
            pilihanOpsiMusic[i].enabled = false;
        }
        pilihanOpsiMusic[index[1]].enabled = true;
    }

    void ApplyInputKeSampingEffect()
    {
        for (int i = 0; i <= maxIndex[2]; i++)
        {
            pilihanOpsiEffect[i].enabled = false;
        }
        pilihanOpsiEffect[index[2]].enabled = true;
    }

    void ApplyInputKeSampingScreen()
    {
        for (int i = 0; i <= maxIndex[3]; i++)
        {
            pilihanOpsiScreen[i].enabled = false;
        }
        pilihanOpsiScreen[index[3]].enabled = true;
    }

    IEnumerator InputHolder()
    {
        inputHold = true;
        yield return new WaitForSeconds(0.4f);
        inputHold = false;
    }

    IEnumerator InputHolder2()
    {
        inputHold2 = true;
        yield return new WaitForSeconds(0.4f);
        inputHold2 = false;
    }

    void ApplySetting() {
        if (index[0] == 3 && Input.GetKeyDown(IM.StartButton[ControlNumber])) {
            SceneManager.LoadScene("Control");
        }
        if (index[0] == 4 && Input.GetKeyDown(IM.StartButton[ControlNumber]))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
