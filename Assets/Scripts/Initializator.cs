using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Initializator : MonoBehaviour
{
    [SerializeField] private BirdLauncherController _birdLauncherController;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private CanvasController _canvasController;
    [SerializeField] private GameInputController _gameInputController;
    private void Awake()
    {
        _birdLauncherController.Initialize();
        _levelManager.Initialize();
        _canvasController.Initialize();
        _gameInputController.Initialize();
    }
}
