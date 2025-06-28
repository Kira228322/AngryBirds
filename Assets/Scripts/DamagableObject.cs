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
    private const float _minVelocityToDamage = 0.5f; 
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _onDestroyHappen = GetComponent<IOnDestroyHappen>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        float relativeVelocity = other.relativeVelocity.magnitude;
        if (relativeVelocity < _minVelocityToDamage)
            return;
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) // объект об землю = v * (m+1) (собственная)
        {   
            ApplyHit(relativeVelocity * (_rigidbody.mass + 1));
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Bird")) // объект об птицу = 2.5vm
        {
            Rigidbody2D rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            ApplyHit(2.5f * relativeVelocity * rigidbody.mass);
        }
        else // объект об объект = v * m
        {
            Rigidbody2D rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            ApplyHit(relativeVelocity * rigidbody.mass);
        }
    }

    public void ApplyHit(float damage)
    {
        if (hp <= 0)
            return;
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
