using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;
    [SerializeField] private TMP_Text _goalText;

    public void Initialize()
    {
        if (Instance == null)
            Instance = this;
    }
    
    public void UpdateGoal()
    {
        _goalText.text = $"{LevelManager.Instance.DefeatedEnemy}/{LevelManager.Instance.GoalEnemy}";
    }
}
