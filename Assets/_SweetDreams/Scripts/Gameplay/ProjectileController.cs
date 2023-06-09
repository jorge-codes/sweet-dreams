using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float lifetime = 3f;
    // [SerializeField] private LayerMask layerMask;
    
    [Space(6)]
    [SerializeField] private Rigidbody2D rigidBody = null;

    private float timer = 0f;
    private Vector2 velocity;

    public void SetDirection(Vector2 direction, float accel = 1f)
    {
        velocity = direction.normalized;
        speed = accel;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < lifetime) return;
        
        Kill();
    }

    private void FixedUpdate()
    {
        var position = (Vector2)transform.position + Time.deltaTime * speed * velocity;
        rigidBody.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Kill();
    }
}
