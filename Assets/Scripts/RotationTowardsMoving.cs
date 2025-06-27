using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTowardsMoving : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float angle = Mathf.Atan(_rigidbody.velocity.y / _rigidbody.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
