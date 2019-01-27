using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random;

namespace GGJ19 {

    [Serializable]
    public struct VoiceSfx
    {
        public string charName;
        public string sfx;
    }

    [Serializable]
    public class VoiceSystem
    {
        public VoiceSfx[] voicesSfx;

        public Dictionary<string, List<string>> voicesDict = new Dictionary<string, List<string>>();

        public void Initialise()
        {
            foreach (var voices in voicesSfx)
            {
                if (voicesDict.ContainsKey(voices.charName))
                {
                    voicesDict[voices.charName].Add(voices.sfx);
                }
                else
                {
                    voicesDict[voices.charName] = new List<string>();
                    voicesDict[voices.charName].Add(voices.sfx);
                }
            }
        }

        public List<string> GetVoice(string charName)
        {
            return voicesDict[charName];
        }
    }


    public class CharacterAnimation : MonoBehaviour
    {
        public Animator controller;

        public string characterName;

        public VoiceSystem system;

        private void Start()
        {
            system.Initialise();
        }

        public void SetEmotion(Emotion emotion)
        {
            controller.SetInteger("stato", (int)emotion);
        }

        public void PlayRandomVoice()
        {
            var voices = system.GetVoice(characterName);
            int i = Random.Range(0, voices.Count);

            SfxManager.I.Play(voices[i]);
        }

    }

}
