using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GGJ19
{
    public enum Winresults { GREAT, GOOD, MEH, BAD }

    public class WinManager : MonoSingleton<WinManager>
    {
        public Image panelGreat;
        string greatMsg = "Great pal! You are perfect for this job! Clients are enthusiast!";

        public Image panelGood;
        string goodMsg = "Good job! Clients are satisfied. Next you'l be perfect! Try again";

        public Image panelMeh;
        string mehMsg = "Try again ... This is barely enough for our clients satisfaction .. I believe you could do better!";

        public Image panelBad;
        string badMsg = "Sorry pal, you failed... Clients are not satisfied! Try Again";

        public TextMeshProUGUI text;

        bool click = false;

        private void Update()
        {
            if (GameManager.I.PHASE == GamePhase.DEATH && Input.GetKeyDown(KeyCode.Space))
            {
                click = true;
            }
        }

        public void Hide()
        {

            text.text = "";

            panelGreat.color = Color.clear;
            panelGood.color = Color.clear;
            panelMeh.color = Color.clear;
            panelBad.color = Color.clear;
        }


        public void ShowWin(int score)
        {
            Winresults finalRes = Winresults.MEH;

            if (score < 350)
            {
                finalRes = Winresults.BAD;
                text.text = badMsg;
            }
            else if (score >= 350 && score < 400)
            {
                finalRes = Winresults.MEH;
                text.text = mehMsg;
            }
            else if (score >= 400 && score <= 550)
            {
                finalRes = Winresults.GOOD;
                text.text = goodMsg;
            }
            else if (score > 550)
            {
                finalRes = Winresults.GREAT;
                text.text = greatMsg;
            }

            Debug.Log(finalRes);


            switch (finalRes)
            {
                case Winresults.GREAT:
                    panelGreat.color = Color.white;
                    break;
                case Winresults.GOOD:
                    panelGood.color = Color.white;
                    break;
                case Winresults.MEH:
                    panelMeh.color = Color.white;
                    break;
                case Winresults.BAD:
                    panelBad.color = Color.white;
                    Debug.Log("color");
                    break;
                default:
                    break;
            }

            click = false;
            StartCoroutine(ShowWinCO());

        }

        IEnumerator ShowWinCO()
        {
            Debug.Log("coroutine");
            Debug.Log(click);
            while (!click)
            {
                yield return null;
            }
            click = false;

            // Hide();
            GameManager.I.GoToMainMenu();
        }

    }
}
