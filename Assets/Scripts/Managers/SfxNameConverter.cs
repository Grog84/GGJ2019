using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GGJ19
{
    [Serializable]
    public struct MSoundName
    {
        public string name;
        public string clipName;
    }

    public class SfxNameConverter : MonoSingleton<SfxNameConverter>
    {

        public MSoundName[] sounds;

        public string GetSfx(string name)
        {
            foreach (var item in sounds)
            {
                if (item.name == name)
                    return item.clipName;
            }

            return "";
        }

    }
}