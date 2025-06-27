using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class SlingerShotPath : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    private const int _positionCount = 20;
    private const float _timeStep = 0.05f;
    private const float _maxTension = 3f;
    private const float _tensionStrength = 4;
    private LineRenderer _lineRenderer;
    private Vector2 _mousePosition;
    private Vector2 _slingShotPivot;
    private float _tension;
    private void Awake()
    {
        _slingShotPivot = _pivot.transform.position;
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _positionCount;
    }

    public void UpdateLine(Vector2 velocity)
    {
        for (int i = 0; i < _positionCount; i++)
        {
            _lineRenderer.SetPosition(i, CalculatePosition(velocity, i * _timeStep));
        }
    }
    
    private Vector2 CalculatePosition(Vector2 velocity, float time)
    {
        return _slingShotPivot + velocity * time + Physics2D.gravity * (time * time * 0.5f);
    }
    
    public void LaunchBird(InputAction.CallbackContext callbackContext)
    {
        if (BirdLauncherController.Instance.SlingShotBird == null)
            return;
        
        BirdLauncherController.Instance.LaunchBird(_tensionStrength * _tension * (_slingShotPivot - _mousePosition).normalized);
        gameObject.SetActive(false);
        GameInputController.Instance.SwitchToOnBirdFlying();
    }

    private void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        _tension = (_slingShotPivot - _mousePosition).magnitude;
        if (_tension > _maxTension)
            _tension = _maxTension;
        
        Vector2 direction = (_slingShotPivot - _mousePosition).normalized;
        UpdateLine(_tensionStrength * _tension * direction);
    }
}
