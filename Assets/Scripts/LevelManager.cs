using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public int GoalEnemy { get; private set; }
    public int DefeatedEnemy{ get; private set; }

    
    public int CurrentLevel;
    private int _maxUnlockedLevel = 1;

    
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
        if (CurrentLevel == _maxUnlockedLevel)
            _maxUnlockedLevel++;
        
        CanvasController.Instance.EnableLevelCompletedPanel(CurrentLevel+1);
    }
}
