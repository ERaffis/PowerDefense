using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class TimeTickSystem : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }

    private const float TICK_TIMER_MAX = 0.2f;

    public static event EventHandler<OnTickEventArgs> OnTick;
    private int tick;
    private float tickTimer;

    public bool shouldTick;

    private void Awake()
    {
        tick = 0;
    }

    private void Update()
    {
        if(shouldTick)
        {
            tickTimer += Time.deltaTime;
            if (tickTimer >= TICK_TIMER_MAX)
            {
                tickTimer -= TICK_TIMER_MAX;
                tick++;

                if (OnTick != null) OnTick(this, new OnTickEventArgs { tick = tick });
            }
        }
    }
}
