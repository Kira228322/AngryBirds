using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bird : MonoBehaviour
{
    private Collider2D _collider;
    protected Rigidbody2D _rigidbody;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnBirdLaunch(Vector2 velocity)
    {
        _collider.enabled = true;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.AddForce(velocity * _rigidbody.mass, ForceMode2D.Impulse);
    }

    public abstract void ActivatePower();
}
