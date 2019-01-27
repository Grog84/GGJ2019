using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ19
{

    public enum GamePhase { EXPLORE, BUILD, DEATH, MENU }
    public class GameManager : MonoSingleton<GameManager>
    {
        int finalScore = 0;

        GamePhase gamePhase;
        public GamePhase PHASE {
            get { return gamePhase; }
            set { gamePhase = value;  }
        }

        bool interacting = false;
        public bool INTERACTING {
            get { return interacting; }
            set { interacting = value; }
        }

        public void GoToBuild()
        {
            StartCoroutine(GoToBuildCO());
        }

        IEnumerator GoToBuildCO()
        {
            Fader.I.FadeOut();
            yield return new WaitForSeconds(2f);

            gamePhase = GamePhase.BUILD;
            SceneManager.LoadScene(2);
            Fader.I.FadeIn();
        }

        public void GoToExplore()
        {
            finalScore += HomeManager.I.GetScore();

            if (finalScore < 0)
            {
                string characterName = HomeManager.buildingHomeName;
                DeathManager.I.ShowDeath(characterName);
            }
            else
            {

                HomeManager.I.AddComposition();

                gamePhase = GamePhase.EXPLORE;
                SceneManager.LoadScene(1);

            }


        }

        public void GoToMainMenu()
        {
            StartCoroutine(GoToMainMenuCO());
        }

        IEnumerator GoToMainMenuCO()
        {
            Fader.I.FadeOut();

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(0);
            Fader.I.FadeIn();
        }

    }
}

