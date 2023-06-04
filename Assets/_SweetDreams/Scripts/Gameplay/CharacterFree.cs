using System;
using UnityEngine;

public class CharacterFree : MonoBehaviour
{
    public event Action<Vector2> DirectionChanged;
    public event Action<Vector2> PositionChanged;

    [SerializeField, Range(0f, 10f)] protected float speed = 5f;
    [SerializeField] protected Rigidbody2D rigidBody = null;
    protected Vector2 direction;
    protected Vector2 prevDirection;
    protected Vector3 prevPosition;
    
    public float Speed => speed;
    public Vector2 Direction => direction;

    protected void Awake()
    {
        prevDirection = direction = Vector2.zero;
        prevPosition = transform.position;
    }

    protected void FixedUpdate()
    {
        MoveCharacter();
    }

    protected void LateUpdate()
    {
        var normalized = direction.normalized;
        var position = transform.position;
        
        if (normalized != prevDirection)
        {
            DirectionChanged?.Invoke(direction);
        }
        prevDirection = direction.normalized;


        if (position != prevPosition)
        {
            PositionChanged?.Invoke(position - prevPosition);
        }
        prevPosition = position;
    }

    protected virtual void MoveCharacter()
    {
        var position = (Vector2)transform.position + Time.deltaTime * speed * direction.normalized;
        rigidBody.MovePosition(position);
    }
}
