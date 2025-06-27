using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
        CanvasController.Instance.enabled = true;
        _levelManager.CurrentLevel = n;
    }
}
