using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IOnDestroyHappen))]
public class DamagableObject : MonoBehaviour
{
    [SerializeField] private float hp;
    private Rigidbody2D _rigidbody;
    private IOnDestroyHappen _onDestroyHappen;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _onDestroyHappen = GetComponent<IOnDestroyHappen>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {   
            ApplyHit(other.relativeVelocity.magnitude * _rigidbody.mass);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Bird"))
        {
            Rigidbody2D rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            ApplyHit(2 * other.relativeVelocity.magnitude * rigidbody.mass);
        }
        else 
        {
            Rigidbody2D rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            ApplyHit(other.relativeVelocity.magnitude * Mathf.Sqrt(rigidbody.mass));
        }
    }

    public void ApplyHit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
            Destroy();
    }

    private void Destroy()
    {
        _onDestroyHappen.OnDestroySomethingHappen();
        Destroy(gameObject);
    }
}
