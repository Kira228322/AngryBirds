using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SlingerShotPath : MonoBehaviour
{
    [SerializeField] private Vector2 _slingShotPivot;
    private int _positionCount = 50;
    private LineRenderer _lineRenderer;
    private float _maxTension = 3f;
    private float _tensionStrenght = 5;
    private Bird _currentBird;
    private Vector2 _mousePosition;

    private GameInput _gameInput;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _positionCount;
    }

    private void OnEnable()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();
        _gameInput.Gameplay.LeftClick.performed += LaunchBird;
    }

    private void OnDisable()
    {
        
    }

    public void UpdateLine(Vector2 velocity)
    {
        for (int i = 0; i < _positionCount; i++)
        {
            _lineRenderer.SetPosition(i, CalculatePosition(velocity, i * 0.1f));
        }
    }
    
    private Vector2 CalculatePosition(Vector2 velocity, float time)
    {
        return _slingShotPivot + velocity * time + Physics2D.gravity * (time * time * 0.5f);
    }
    
    public void LaunchBird(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("!");
        enabled = false;
    }

    private void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        float tension = (_slingShotPivot - _mousePosition).magnitude;
        if (tension > _maxTension)
            tension = _maxTension;
        
        Vector2 direction = (_slingShotPivot - _mousePosition).normalized;
        UpdateLine(_tensionStrenght * tension * direction);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
