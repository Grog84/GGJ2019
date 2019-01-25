using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GGJ19
{
    [Serializable]
    public class MTime
    {
        [Range(0, 59)]
        public int minutes;

        [Range(0, 59)]
        public int seconds;

        [Range(0, 1000)]
        public int mseconds;

        public float ToSec()
        {
            return minutes * 60 + seconds + mseconds / 1000f;
        }

        public override string ToString()
        {
            return minutes + " : " + seconds;
        }

        public void SetMax()
        {
            minutes = 59;
            seconds = 59;
        }

        public static bool operator<=(MTime a, MTime b)
        {
            return Comparison(a, b) <= 0;
        }

        public static bool operator >=(MTime a, MTime b)
        {
            return Comparison(a, b) >= 0;
        }

        public static bool operator <(MTime a, MTime b)
        {
            return Comparison(a, b) < 0;
        }

        public static bool operator >(MTime a, MTime b)
        {
            return Comparison(a, b) > 0;
        }

        public static bool operator ==(MTime a, MTime b)
        {
            return Comparison(a, b) == 0;
        }

        public static bool operator !=(MTime a, MTime b)
        {
            return Comparison(a, b) != 0;
        }

        public override bool Equals(object obj)
        {

            if (!(obj is MTime)) return false;

            return this == (MTime)obj;

        }

        public static int Comparison(MTime a, MTime b)
        {
            if (a.ToSec() < b.ToSec())
                return -1;
            else if (a.ToSec() == b.ToSec())
                return 0;
            else if (a.ToSec() > b.ToSec())
                return 1;

            return 0;
        }

    }

}


