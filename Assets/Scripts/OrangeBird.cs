using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBird : Bird
{
    private float _addititionalSpeed = 10f;
    public override void ActivatePower()
    {
        _rigidbody.velocity += _rigidbody.velocity.normalized * _addititionalSpeed;
    }
}
