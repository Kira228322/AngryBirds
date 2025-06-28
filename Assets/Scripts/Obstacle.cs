using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IOnDestroyHappen
{
    [SerializeField] private ParticleSystem _destroyingParticles;
    public void OnDestroySomethingHappen()
    {
        _destroyingParticles.gameObject.SetActive(true);
        _destroyingParticles.transform.SetParent(null);
        Destroy(_destroyingParticles, 3);
    }
}
