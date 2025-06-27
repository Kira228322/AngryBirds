using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedPanel : MonoBehaviour
{
    [SerializeField] private Button _goToNextLevelButton;
    [SerializeField] private LevelTransitionManager _levelTransitionManager;
    
    public void SetNextLevelButton(int n)
    {
        _goToNextLevelButton.onClick.AddListener(() => _levelTransitionManager.LoadScene(n));
    }
}
