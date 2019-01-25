using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{

    public class Timer
    {
        public enum TimerState { READY, ENDED, STOPPED, PUASED, RUNNING }

        private float time;
        public float TIME { get { return time; } set { time = value; } }

        private float timerLimit;
        private TimerState state;

        public Timer()
        {
            time  = 1.0f;
            timerLimit = 1.0f;
            state = TimerState.READY;
        }

        public bool Update()
        {
            if (state != TimerState.RUNNING)
            {
                return false;
            }

            float DT = Time.deltaTime;
            time += DT;

            bool ended = time >= timerLimit;

            if (ended)
                state = TimerState.ENDED;

            return ended;
        }

        public void Start(float limit)
        {
            time = 0.0f;
            timerLimit = limit;

            state = TimerState.RUNNING;
        }

        public void Stop()
        {
            state = TimerState.STOPPED;
        }

        public void Pause()
        {
            state = TimerState.PUASED;
        }

        public void Resume()
        {
            state = TimerState.RUNNING;
        }

        public void Skip(float timeSkip)
        {
            time += timeSkip;
        }


        public float progress
        {
            get
            {
                if (state == TimerState.ENDED) return 1.0f;
                if (state == TimerState.READY) return 0.0f;

                return time / timerLimit;
            }

            set { time = timerLimit * value; }
        }

        public float timeRemained
        {
            get
            {
                return Mathf.Clamp(timerLimit - time, 0.0f, timerLimit);
            }
        }

        public float duration { get { return timerLimit; } }

        public bool running { get { return state == TimerState.RUNNING; } }
        public bool ended { get { return state == TimerState.ENDED; } }
        public bool ready { get { return state == TimerState.READY; } }

    }
}
