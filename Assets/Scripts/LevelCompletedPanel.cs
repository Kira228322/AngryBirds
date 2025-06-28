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
        if (n > LevelManager.Instance.MaxLevel)
            _goToNextLevelButton.interactable = false;
        _goToNextLevelButton.onClick.AddListener(() => _levelTransitionManager.LoadScene(n));
    }
}
