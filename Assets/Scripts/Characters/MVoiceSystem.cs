using System.Collections.Generic;
using System;

namespace GGJ19
{
    public class MVoiceSystem: MonoSingleton<MVoiceSystem>
    {
        public VoiceSfx[] voicesSfx;

        public Dictionary<string, List<string>> voicesDict = new Dictionary<string, List<string>>();

        protected override void Initialise()
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

}
