using UnityEngine;

namespace GGJ19
{
    public static class TransformDeepChildExtension
    {
        //Breadth-first search
        public static Transform FindDeepChild(this Transform aParent, string aName)
        {
            var result = aParent.Find(aName);
            if (result != null)
                return result;
            foreach (Transform child in aParent)
            {
                result = child.FindDeepChild(aName);
                if (result != null)
                    return result;
            }
            return null;
        }

        //Breadth-first search
        public static Transform FindDeepChildByTag(this Transform aParent, string tag)
        {

            if (aParent.childCount != 0)
            {
                foreach (Transform child in aParent)
                {
                    if (child.tag == tag)
                    {
                        var result = child;
                        return result;
                    }
                    else
                    {
                        var result = child.FindDeepChildByTag(tag);
                        if (result != null)
                            return result;
                    }
                }
            }

            return null;

        }


        //Breadth-first search
        public static T FindComponentInDeepChild<T>(this Transform aParent, string aName)
        {
            var result = aParent.Find(aName);
            if (result != null)
                return result.GetComponent<T>();
            foreach (Transform child in aParent)
            {
                result = child.FindDeepChild(aName);
                if (result != null)
                    return result.GetComponent<T>();
            }
            return default(T);
        }

    }
}