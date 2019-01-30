using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GGJ19
{
    public class SfxManager : MonoSingleton<SfxManager>
    {
        private SoundManager soundManager;

        private AudioSource[] audioSources;
        private string[] audioSourcesNames;

        private int firstEmptySource = 0;


        protected override void Initialise()
        {
            soundManager = gameObject.AddComponent<SoundManager>();

            audioSources = new AudioSource[9];
            audioSourcesNames = new string[9];

            for (int i = 0; i < 9; i++)
            {
                audioSources[i] = gameObject.AddComponent<AudioSource>();

                audioSources[i].playOnAwake = false;
            }     
        }

        public void Play(string sfxName)
        {
            var idx = Array.IndexOf(audioSourcesNames, sfxName);
            if (idx > -1)
            {
                audioSources[idx].Play();
            }
            else
            {
                audioSourcesNames[firstEmptySource] = sfxName;
                audioSources[firstEmptySource].clip = soundManager.GetSFX(sfxName);
                audioSources[firstEmptySource].Play();

                firstEmptySource++;
                firstEmptySource %= 9;
            }
        }

    }
}