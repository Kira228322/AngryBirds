using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlingShotZoneActivation : MonoBehaviour,  IPointerDownHandler
{
    [SerializeField] private SlingerShotPath _shotPath;

    public void OnPointerDown(PointerEventData eventData)
    {
        _shotPath.enabled = true;
    }
    

}
