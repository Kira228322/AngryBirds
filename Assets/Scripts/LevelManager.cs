using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public int GoalEnemy { get; private set; }
    public int DefeatedEnemy{ get; private set; }

    
    public int CurrentLevel;
    [HideInInspector] public int MaxUnlockedLevel = 1;
    public readonly int MaxLevel = 5;
    
    public void Awake()
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
            LevelCompleted();
        }
    }

    public void ResetGoal()
    {
        GoalEnemy = 0;
        DefeatedEnemy = 0;
    }
    
    private void LevelCompleted()
    {
        if (CurrentLevel == MaxUnlockedLevel && CurrentLevel != MaxLevel)
            MaxUnlockedLevel++;
        
        CanvasController.Instance.EnableLevelCompletedPanel(CurrentLevel+1);
    }
}
