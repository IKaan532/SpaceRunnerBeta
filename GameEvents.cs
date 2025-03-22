using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class GameEvents : MonoBehaviour
{
    private static List<IObserver> observers = new List<IObserver>();

    public static event Action GameStarted;
    public static event Action GameEnded;

    public static bool IsGameStarted { get; private set; }

    public static void AddObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public static void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public static void TriggerGameStart()
    {
        if (IsGameStarted) return;

        IsGameStarted = true;
        GameStarted?.Invoke();
        
        foreach (var observer in observers)
        {
            observer.OnGameStart();
        }
    }

    public static void TriggerGameEnd()
    {
        if (!IsGameStarted) return;

        IsGameStarted = false;
        GameEnded?.Invoke();

        foreach (var observer in observers)
        {
            observer.OnGameEnd();
        }
    }
}

