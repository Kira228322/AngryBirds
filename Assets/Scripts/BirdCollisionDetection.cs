using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotationTowardsMoving))]
public class BirdCollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (BirdLauncherController.Instance.FlyingBird != null)
        {
            Debug.Log("Ne null" + BirdLauncherController.Instance.FlyingBird);
            if (BirdLauncherController.Instance.FlyingBird.gameObject == gameObject)
            {
                Debug.Log("!@!@");
                BirdLauncherController.Instance.FlyingBird = null;
                GameInputController.Instance.SwitchToGameplay();
            }
        }
        GetComponent<RotationTowardsMoving>().enabled = false;
        Destroy(this);
    }
}
