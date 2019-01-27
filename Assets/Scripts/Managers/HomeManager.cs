using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class HomeManager : MonoSingleton<HomeManager>
    {
        public Home activeHome;

        public void SetItemInPosition(CharacterItem item, Position pos)
        {
            activeHome.SetItem(item, pos);
        }
    }

}
