using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputController : MonoBehaviour
{
    public static GameInputController Instance;
    [SerializeField] private SlingerShotPath _shotPath;
    [SerializeField] private SlingShotZoneActivation _slingShotZone;
    private GameInput _gameInput;

    public void Initialize()
    {
        if (Instance == null)
            Instance = this;
        
        _gameInput = new GameInput();
        _gameInput.Enable();

        _gameInput.Gameplay.LeftClick.performed += _slingShotZone.OnLeftMouseClick;
        _gameInput.Gameplay.LeftClick.canceled += _shotPath.LaunchBird;
        _gameInput.OnBirdFlying.LeftClick.performed += BirdLauncherController.Instance.ActivateCurrentBirdPower;
        
        _gameInput.Gameplay.Enable();
        _gameInput.OnBirdFlying.Disable();
    }

    public void SwitchToGameplay()
    {
        _gameInput.Gameplay.Enable();
        _gameInput.OnBirdFlying.Disable();
    }
    
    public void SwitchToOnBirdFlying()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.OnBirdFlying.Enable();
    }

    public void DisableInput()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.OnBirdFlying.Disable();
    }
}
