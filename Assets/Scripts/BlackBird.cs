using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    [SerializeField] private ContactFilter2D _contactFilter;
    private float _explosionRadius = 1.75f;
    private float _explosionForce = 20;
    public override void ActivatePower()
    {
        List<Collider2D> _colliders = new List<Collider2D>();
        Physics2D.OverlapCircle(gameObject.transform.position, _explosionRadius, _contactFilter, _colliders);
        
        foreach (var collider in _colliders)
        {
            Vector2 force = collider.transform.position - gameObject.transform.position;
            float distance = force.magnitude;
            force += Vector2.up * 3; 
            force = force.normalized;
            force /= distance;
            force *= _explosionForce;
            collider.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }
    }
}
