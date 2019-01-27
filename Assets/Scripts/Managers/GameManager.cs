﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ19
{

    public enum GamePhase { EXPLORE, BUILD }
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
            gamePhase = GamePhase.BUILD;
            SceneManager.LoadScene(1);
        }

        public void GoToExplore()
        {
            finalScore += HomeManager.I.GetScore();

            HomeManager.I.AddComposition();

            gamePhase = GamePhase.EXPLORE;
            SceneManager.LoadScene(0);

        }

    }
}

