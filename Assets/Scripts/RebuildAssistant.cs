using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class RebuildAssistant : MonoBehaviour
    {
        private void OnEnable()
        {
            if (HomeManager.I != null)
            {
                HomeManager.I.RebuildFinishedHouses();
            }
        }
    }
}
