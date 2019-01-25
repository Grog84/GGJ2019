using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace GGJ19 {

    public class SoundManager : ResourceManager<AudioClip> {

        public AudioClip GetSFX(string sfxName)
        {
            AudioClip sfx;

            sfx = LoadClip(Path.Combine("Sfx", SfxNameConverter.I.GetSfx(sfxName)));

            //sfx = ConfigManager.SoundStyle.GetSfx(sfxName);

            //if(sfx == null)
            //    sfx = LoadClip(Path.Combine("Sfx", sfxName));

            return sfx;
        }
    }

}
