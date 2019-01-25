using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19 {

    public class ResourceManager<T> : MonoBehaviour where T : UnityEngine.Object
    {

        protected Dictionary<string, T> resourcesCache = new Dictionary<string, T>();

        public virtual void PreloadResources()
        {

        }

        public void UnloadCachedResources()
        {
            resourcesCache.Clear();
        }

        protected T LoadClip(string resName)
        {
            if (!resourcesCache.ContainsKey(resName))
            {
                resourcesCache[resName] = Resources.Load<T>(resName);
            }
            return resourcesCache[resName];
        }

    }

}

