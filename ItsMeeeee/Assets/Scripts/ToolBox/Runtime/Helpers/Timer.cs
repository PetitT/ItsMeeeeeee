using System;
using UnityEngine;

namespace LowTeeGames
{
    public static class Timer
    {
        public static void LoopedCountDown(ref float timer, float maximumTime, Action onFinish)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            if (timer <= 0)
            {
                onFinish?.Invoke();
                timer = maximumTime;
            }
        }

        public static void CountDown(ref float timer, Action onFinish)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    onFinish?.Invoke();
                }
            }
        }
    }
}
