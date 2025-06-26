using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLauncherController : MonoBehaviour
{
    [SerializeField] private List<Bird> _birdsList = new();
    [SerializeField] private Transform _SlingerShotPivot;
    public Bird CurrentBird { get; private set; }

    private Stack<Bird> _birds;

    private void Awake()
    {
        _birds = new Stack<Bird>(_birdsList);
        CurrentBird = _birds.Pop();
    }

    public void LaunchBird(Vector2 velocity)
    {
        CurrentBird.OnBirdLaunch(velocity);
        if (_birds.TryPop(out Bird bird))
        {
            StartCoroutine(PlacingBirdIntoSlingerShot(bird));
        }
    }

    private IEnumerator PlacingBirdIntoSlingerShot(Bird bird)
    {
        float timeStep = 0.02f;
        WaitForSeconds deltaTime = new WaitForSeconds(timeStep);
        float animationTime = 1.5f;
        
        Vector2 startPosition = bird.transform.position;
        Quaternion startRotation = bird.transform.rotation;
        float x, y;
        
        for (float i = 0; i <= 1; i+= timeStep/animationTime)
        {
            x = Mathf.Lerp(startPosition.x, _SlingerShotPivot.position.x, i);
            
            y = Mathf.Lerp(startPosition.y, _SlingerShotPivot.position.y, (float)Math.Sqrt(i));
            
            bird.transform.position = new Vector2(x, y);
            
            bird.transform.rotation = startRotation * Quaternion.Euler(0,0, -360 * i);
            
            yield return deltaTime;
        }

        CurrentBird = bird;
    }
}
