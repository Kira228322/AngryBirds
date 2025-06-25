using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnBirdLaunch(Vector2 velocity)
    {
        _collider.enabled = true;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.AddForce(velocity, ForceMode2D.Impulse);
    }
}
