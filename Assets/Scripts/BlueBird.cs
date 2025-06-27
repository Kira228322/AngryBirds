using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : Bird
{
    public override void ActivatePower()
    {
        GameObject topBird = Instantiate(gameObject);
        GameObject bottomBird = Instantiate(gameObject);
        
        topBird.transform.position += gameObject.transform.up;
        bottomBird.transform.position += -gameObject.transform.up;
        
        topBird.GetComponent<Rigidbody2D>().velocity = _rigidbody.velocity;
        bottomBird.GetComponent<Rigidbody2D>().velocity = _rigidbody.velocity;
    }
}
