using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SlingShotZoneActivation : MonoBehaviour
{
    [SerializeField] private LayerMask _LaunchZoneMask;
    [SerializeField] private SlingerShotPath _shotPath;
    private bool CheckCursorInArea()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Physics2D.Raycast(mousePos, Vector2.zero, 1, _LaunchZoneMask))
            return true;
        return false;
    }

    public void OnLeftMouseClick(InputAction.CallbackContext callbackContext)
    {
        if (!CheckCursorInArea())
            return;
        
        _shotPath.gameObject.SetActive(true);
    }
    
    
}
