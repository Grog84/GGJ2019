using UnityEngine;

namespace GGJ19
{
    public class Singleton<T> where T : new()
    {
        private static T _instance;
        public static T I
        {
            get
            {
                if (_instance == null) _instance = new T();
                return _instance;
            }
        }
    }

    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T I
        {
            get { return _instance; }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
            }
            else
            {
                Destroy(gameObject);
            }
            Initialise();
        }

        protected virtual void Initialise()
        {
        }
    }
}