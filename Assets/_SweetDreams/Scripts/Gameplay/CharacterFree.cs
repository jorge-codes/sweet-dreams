using System;
using UnityEngine;

public class CharacterFree : MonoBehaviour
{
    public event Action<Vector2> DirectionChanged;
    public event Action<Vector2> PositionChanged;
    public event Action<Vector2> LookDirectionChanged;


    [SerializeField, Range(0f, 10f)] protected float speed = 5f;
    [SerializeField] protected Vector2 initalLookAt = Vector2.down;
    [SerializeField] protected Rigidbody2D rigidBody = null;
    protected Vector2 velocity;
    protected Vector2 direction;
    protected Vector2 prevVelocity;
    protected Vector3 prevPosition;
    
    public float Speed => speed;
    public Vector2 Velocity => velocity;
    public Vector2 Direction => direction;

    public virtual void Kill()
    {
        Destroy(gameObject);
    }

    protected virtual void Awake()
    {
        prevVelocity = velocity = Vector2.zero;
        prevPosition = transform.position;
        
        LookDirectionChanged?.Invoke(initalLookAt);
    }

    protected void FixedUpdate()
    {
        MoveCharacter();
    }

    protected void LateUpdate()
    {
        var normalized = velocity.normalized;
        var position = transform.position;
        
        if (normalized != prevVelocity)
        {
            DirectionChanged?.Invoke(velocity);
            if (velocity.sqrMagnitude > 0f)
            {
                direction = velocity.normalized;
                LookDirectionChanged?.Invoke(direction);
            }
        }
        prevVelocity = velocity.normalized;


        if (position != prevPosition)
        {
            PositionChanged?.Invoke(position - prevPosition);
        }
        prevPosition = position;
    }

    protected virtual void MoveCharacter()
    {
        var position = (Vector2)transform.position + Time.deltaTime * speed * velocity.normalized;
        rigidBody.MovePosition(position);
    }
}
