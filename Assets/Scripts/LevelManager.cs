using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public int GoalEnemy { get; private set; }
    public int DefeatedEnemy{ get; private set; }

    public void Initialize()
    {
        if (Instance == null)
            Instance = this;
    }

    public void CountEnemy()
    {
        GoalEnemy++;
    }

    public void OnEnemyDefeated()
    {
        DefeatedEnemy++;
        if (DefeatedEnemy == GoalEnemy)
        {
            Debug.Log("WIN");
        }
    }
}
