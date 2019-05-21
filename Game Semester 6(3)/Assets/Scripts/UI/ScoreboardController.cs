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
        for (int i = 0; i < GoldCrown.Length; i++) {
            GoldCrown[i].enabled = false;
        }
        for (int i = 0; i < SilverCrown.Length; i++)
        {
            SilverCrown[i].enabled = false;
        }
        for (int i = 0; i < BronzeCrown.Length; i++)
        {
            BronzeCrown[i].enabled = false;
        }
        canvasScoreboard.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeout.startTimer == 0) {
            SortLeaderBoard();
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


    public void SortLeaderBoard()
    {
        for (int i = 0; i < ca.skorPlayer.Length; i++)
        {
            if (ca.tempSkorPlayer[0] == ca.skorPlayer[i])
            {
                GoldCrown[i].enabled = true;
            }
            if (ca.tempSkorPlayer[1] == ca.skorPlayer[i])
            {
                SilverCrown[i].enabled = true;
            }
            if (ca.tempSkorPlayer[2] == ca.skorPlayer[i])
            {
                BronzeCrown[i].enabled = true;
            }
        }
    }
}
