using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        BirdLauncherController.Instance.FlyingBird = null;
        GameInputController.Instance.SwitchToGameplay();
        Destroy(this);
    }
}
