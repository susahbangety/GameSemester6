using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class ScoreboardController : MonoBehaviour
{
    public Text[] SkorText;
    public Text[] DeathText;
    public Image[] GoldCrown;
    public Image[] SilverCrown;
    public Image[] BronzeCrown;
    public CharacterAttributes ca;
    public Timer timeout;
    public Canvas canvasScoreboard;

    // Start is called before the first frame update
    void Start()
    {
        canvasScoreboard.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeout.startTimer == 0) {
            canvasScoreboard.enabled = true;
            for (int i = 0; i < 4; i++) {
                TampilkanSkor(i);
                TampilkanDeath(i);
            }

        }
    }


    public void TampilkanSkor(int i) {
        SkorText[i].text = " " + ca.skorPlayer[i];
    }

    public void TampilkanDeath(int i) {
        DeathText[i].text = " " + ca.playerDeath[i];
    }
}
