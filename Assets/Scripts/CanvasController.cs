using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;
    [SerializeField] private TMP_Text _goalText;
    [SerializeField] private LevelCompletedPanel _levelCompletedPanel;
    [SerializeField] private GameObject _levelsPanel;
    public void Initialize()
    {
        if (Instance == null)
            Instance = this;
    }
    
    public void UpdateGoal()
    {
        _goalText.text = $"{LevelManager.Instance.DefeatedEnemy}/{LevelManager.Instance.GoalEnemy}";
    }

    public void EnableLevelCompletedPanel(int n)
    {
        _levelCompletedPanel.gameObject.SetActive(true);
        _levelCompletedPanel.SetNextLevelButton(n);
    }

    public void SwitchLevelsPanel()
    {
        _levelsPanel.SetActive(!_levelsPanel.activeSelf);
    }
}
