using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdLauncherController : MonoBehaviour
{
    public static BirdLauncherController Instance;
    [HideInInspector] public Bird FlyingBird; 
    public Bird SlingShotBird { get; private set; }
    [SerializeField] private List<Bird> _birdsList = new();
    [SerializeField] private Transform _SlingerShotPivot;
    
    private Stack<Bird> _birds;

    private void Awake()
    {
        _birds = new Stack<Bird>(_birdsList);
        _birdsList.Clear();
        if (_birds.TryPop(out Bird bird))
        {
            StartCoroutine(PlacingBirdIntoSlingerShot(bird));
        }
    }

    public void Initialize()
    {
        if (Instance == null)
            Instance = this;
    }

    public void LaunchBird(Vector2 velocity)
    {
        SlingShotBird.OnBirdLaunch(velocity);
        FlyingBird = SlingShotBird;
        SlingShotBird = null;
        if (_birds.TryPop(out Bird bird))
        {
            StartCoroutine(PlacingBirdIntoSlingerShot(bird));
        }
    }

    private IEnumerator PlacingBirdIntoSlingerShot(Bird bird)
    {
        float timeStep = 0.02f;
        WaitForSeconds deltaTime = new WaitForSeconds(timeStep);
        float animationTime = 0.75f;
        
        Vector2 startPosition = bird.transform.position;
        Quaternion startRotation = bird.transform.rotation;
        float x, y;
        
        for (float i = 0; i <= 1; i+= timeStep/animationTime)
        {
            x = Mathf.Lerp(startPosition.x, _SlingerShotPivot.position.x, i);
            y = Mathf.Lerp(startPosition.y, _SlingerShotPivot.position.y, Mathf.Sqrt(i));
            bird.transform.position = new Vector2(x, y);
            
            bird.transform.rotation = startRotation * Quaternion.Euler(0,0, -360 * i);
            
            yield return deltaTime;
        }

        SlingShotBird = bird;
        SlingShotBird.GetComponent<RotationTowardsMoving>().enabled = true;
    }

    public void ActivateCurrentBirdPower(InputAction.CallbackContext callbackContext)
    {
        if (FlyingBird == null)
            return;
        FlyingBird.ActivatePower();
        GameInputController.Instance.SwitchToGameplay();
    }
}
