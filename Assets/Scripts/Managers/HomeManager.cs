using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{


    public class HomeManager : MonoSingleton<HomeManager>
    {
        public Home activeHome;
        public Home buildingHome;

        public void SetActiveHome(Home home)
        {
            activeHome = home;
        }

        public void SetBuildingHome(Home home)
        {
            buildingHome = home;
        }

        public void SetItemInPosition(CharacterItem item, Position pos)
        {
            activeHome.SetItem(item, pos);
        
        }

        public CharacterItem GetItemInPosition(Position pos)
        {
            return activeHome.GetItem(pos);

        }
    }

}
