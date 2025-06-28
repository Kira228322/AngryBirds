using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    [SerializeField] private GameObject _explosion; 
    [SerializeField] private ContactFilter2D _contactFilter;
    private float _damagePerDistance = 12; 
    private float _explosionRadius = 2f;
    private float _explosionForce = 20f;
    public override void ActivatePower()
    {
        _explosion.SetActive(true);
        _explosion.transform.SetParent(null);
        
        List<Collider2D> _colliders = new List<Collider2D>();
        Physics2D.OverlapCircle(gameObject.transform.position, _explosionRadius, _contactFilter, _colliders);
        
        foreach (var collider in _colliders)
        {
            Vector2 closestPoint = collider.ClosestPoint(gameObject.transform.position);
            Vector2 force = closestPoint - (Vector2)gameObject.transform.position;
            float distance = force.magnitude;
            force += Vector2.up * 3; 
            force = force.normalized;
            force /= distance;
            force *= _explosionForce;
            collider.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            
            if (collider.TryGetComponent(out DamagableObject component))
            {
                component.ApplyHit(_damagePerDistance/distance);
            }
        }
    }
    
}
