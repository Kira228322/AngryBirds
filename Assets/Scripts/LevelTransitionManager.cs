using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    public void LoadScene(int n)
    {
        if (GameInputController.Instance != null)
            GameInputController.Instance.DisableInput();
        LevelManager.Instance.ResetGoal();
        SceneManager.LoadScene(n);
        LevelManager.Instance.CurrentLevel = n;
    }

    public void ReloadLevel()
    {
        if (GameInputController.Instance != null)
            GameInputController.Instance.DisableInput();
        LevelManager.Instance.ResetGoal();
        SceneManager.LoadScene(LevelManager.Instance.CurrentLevel);
    }
}
