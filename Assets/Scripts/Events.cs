using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static Action OnCoinCollected;

    public static Action OnPlayerWin;
    public static Action OnPlayerLose;

    public static void SendCoinCollected()
    {
        if (OnCoinCollected != null)
        {
            OnCoinCollected.Invoke();
        }
    }

    public static void SendPlayerWin()
    {
        if (OnPlayerWin != null)
        {
            OnPlayerWin.Invoke();
        }
    }
    public static void SendPlayerLose()
    {
        if (OnPlayerLose != null)
        {
            OnPlayerLose.Invoke();
        }
    }
}
