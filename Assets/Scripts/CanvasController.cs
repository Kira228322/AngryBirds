using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;
    [SerializeField] private TMP_Text _goalText;
    [SerializeField] private LevelCompletedPanel _levelCompletedPanel;
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private List<Button> _levelButtons; 
    public void Initialize()
    {
        if (Instance == null)
            Instance = this;
        
        for (int i = 0; i < LevelManager.Instance.MaxUnlockedLevel; i++)
        {
            _levelButtons[i].interactable = true;
        }
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
