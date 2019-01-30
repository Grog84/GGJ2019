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
        int finishedHomes = 0;
        public int FinishedHomes { get { return finishedHomes; } }

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

        PlayerMovement player;



        private void OnEnable()
        {
            player = FindObjectOfType<PlayerMovement>();
        }

        public void GoToBuild()
        {
            StartCoroutine(GoToBuildCO());
        }

        IEnumerator GoToBuildCO()
        {
            interacting = true;

            Fader.I.FadeOut();
            yield return new WaitForSeconds(2f);

            var activeHome = HomeManager.I.ACTIVE_HOME;

            player.transform.position = activeHome.transform.position;
            activeHome.SetCameraActive(true);
            UIItemList.I.Show();

            gamePhase = GamePhase.BUILD;
            Fader.I.FadeIn();

            interacting = false;
        }

        public void GoToExplore()
        {
            StartCoroutine(GoToExploreCO());
        }


        IEnumerator GoToExploreCO()
        {
            interacting = true;

            var home = HomeManager.I.ACTIVE_HOME;

            UIItemList.I.Hide();
            yield return new WaitForSeconds(2f);
            Fader.I.FadeOut();
            yield return new WaitForSeconds(2f);

            home.SetCameraActive(false);
            CameraManager.I.StartFollowing(home.transform);

            Fader.I.FadeIn();
            yield return new WaitForSeconds(2f);

            finalScore += HomeManager.I.GetScore();

            

            player.SetCollidersActive(false);

            home.MoveCharacterIn();
            yield return new WaitForSeconds(5f);

            player.SetCollidersActive(true);

            yield return StartCoroutine( DialogueManager.I.ShowEmotion(home.character.Emotion));

            if (finalScore < 0)
            {
                gamePhase = GamePhase.DEATH;

                string characterName = HomeManager.I.ACTIVE_HOME.character.m_name;
                DeathManager.I.ShowDeath(characterName);
            }
            else
            {
                finishedHomes++;
                CameraManager.I.Reset();
                gamePhase = GamePhase.EXPLORE;
                
            }

            interacting = false;

        }

        public void Win()
        {
            StartCoroutine(WinCO());
        }

        IEnumerator WinCO()
        {
            gamePhase = GamePhase.DEATH;

            yield return StartCoroutine(DialogueManager.I.ShowEnd());

            SfxManager.I.Play("sfx_rullo");
            Fader.I.FadeOut();
            yield return new WaitForSeconds(3);

            WinManager.I.ShowWin(finalScore);

            Fader.I.FadeIn();


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

