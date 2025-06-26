using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IOnDestroyHappen
{
    private void Start()
    {
        LevelManager.Instance.CountEnemy();
        CanvasController.Instance.UpdateGoal();
    }

    public void OnDestroySomethingHappen()
    {
        LevelManager.Instance.OnEnemyDefeated();
        CanvasController.Instance.UpdateGoal();
    }
}
