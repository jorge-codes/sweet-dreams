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
    protected Vector2 direction;
    protected Vector2 lookingAt;
    protected Vector2 prevDirection;
    protected Vector3 prevPosition;
    
    public float Speed => speed;
    public Vector2 Direction => direction;
    public Vector2 LookingAt => lookingAt;

    protected virtual void Awake()
    {
        prevDirection = direction = Vector2.zero;
        prevPosition = transform.position;
        
        LookDirectionChanged?.Invoke(initalLookAt);
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
            if (direction.sqrMagnitude > 0f)
            {
                lookingAt = direction.normalized;
                LookDirectionChanged?.Invoke(lookingAt);
            }
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
