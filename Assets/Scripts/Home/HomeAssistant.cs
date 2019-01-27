using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class HomeAssistant : MonoBehaviour
    {
        public Home home;
        private void Start()
        {
            HomeManager.I.SetActiveHome(home);
            GameManager.I.PHASE = GamePhase.BUILD;
        }
    }
}
