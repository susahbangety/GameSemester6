using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuHandler : MonoBehaviour
{
    [Header("Buat Inputan")]
    public InputManager IM;
    public int ControlNumber;

    public Image[] ImageSelected;
    public int index;
    public int maxIndex;

    public bool inputHold;
    public Vector3 inputAxis;

    public Image BackgroundBerputar;
    public float value;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        maxIndex = ImageSelected.Length-1;
        inputHold = false;
        ApplyInput();
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundBerputar.rectTransform.Rotate(new Vector3(0, 0, value));
        GetInputAxis();
        if (inputAxis.z > 0.2f || inputAxis.z < -0.2f )
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

    void GetInputAxis() {
        inputAxis.z = Input.GetAxis(IM.VerticalAxis[ControlNumber]);
    }

    void PindahInput() {
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

    void ApplyInput()
    {
        for (int i = 0; i <= maxIndex; i++)
        {
            ImageSelected[i].enabled = false;
        }
        ImageSelected[index].enabled = true;
    }

    IEnumerator InputHolder() {
        inputHold = true;
        yield return new WaitForSeconds(0.4f);
        inputHold = false;
    }


    void CheckInput()
    {
        if (index == 0 && Input.GetKeyDown(IM.XButton[ControlNumber]))
        {
            SceneManager.LoadScene("PlayerSelection");
        }
        if (index == 1 && Input.GetKeyDown(IM.XButton[ControlNumber]))
        { 
            SceneManager.LoadScene("Credit");
        }
        if (index == 2 && Input.GetKeyDown(IM.XButton[ControlNumber]))
        {
            SceneManager.LoadScene("Option");
        }
        if (index == 3 && Input.GetKeyDown(IM.XButton[ControlNumber]))
        {
            Application.Quit();
        }
    }
}
