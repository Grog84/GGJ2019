using System.Collections;
using UnityEngine;

using Random = UnityEngine.Random;

namespace GGJ19
{


    public class CharacterAnimation : MonoBehaviour
    {
        public Animator controller;

        public string characterName = "";


        public void SetEmotion(Emotion emotion)
        {
            controller.SetInteger("stato", (int)emotion);
            PlayRandomVoice();
        }

        public void PlayRandomVoice()
        {
            var voices = VoiceSystem.I.GetVoice(characterName);
            int i = Random.Range(0, voices.Count);

            SfxManager.I.Play(voices[i]);
        }

    }

}
