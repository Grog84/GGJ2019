using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public bool interacting = false;
        public bool INTERACTING {
            get { return interacting; }
            set { interacting = value; }
        }

    }
}

