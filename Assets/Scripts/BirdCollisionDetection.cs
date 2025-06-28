using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotationTowardsMoving))]
public class BirdCollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (BirdLauncherController.Instance.FlyingBird != null)
            if (BirdLauncherController.Instance.FlyingBird.gameObject == gameObject)
            {
                BirdLauncherController.Instance.FlyingBird = null;
                GameInputController.Instance.SwitchToGameplay();
            }
        
        GetComponent<RotationTowardsMoving>().enabled = false;
        Destroy(this);
    }
}
