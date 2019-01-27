using UnityEngine;

namespace GGJ19
{
    [CreateAssetMenu]
    public class DeathEntry: ScriptableObject
    {
        public string character;
        public CharacterItem item;
        [TextArea]
        public string text;
    }

}
