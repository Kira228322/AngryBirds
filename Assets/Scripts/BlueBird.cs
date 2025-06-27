using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : Bird
{
    public override void ActivatePower()
    {
        GameObject topBird = Instantiate(gameObject);
        GameObject bottomBird = Instantiate(gameObject);
        
        topBird.transform.position += Vector3.up;
        bottomBird.transform.position += Vector3.down;

        topBird.GetComponent<Rigidbody2D>().velocity = _rigidbody.velocity;
        bottomBird.GetComponent<Rigidbody2D>().velocity = _rigidbody.velocity;
    }
}
