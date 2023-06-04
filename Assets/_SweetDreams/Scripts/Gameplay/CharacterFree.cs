using System;
using UnityEngine;

public class CharacterFree : MonoBehaviour
{
    public event Action<Vector2> DirectionChanged; 

    [SerializeField, Range(0f, 10f)] protected float speed = 5f;
    [SerializeField] protected Rigidbody2D rigidBody = null;
    protected Vector2 direction;
    protected Vector2 prevDirection;
    
    public float Speed => speed;
    public Vector2 Direction => direction;

    protected void Awake()
    {
        prevDirection = direction = Vector2.zero;
    }

    protected void FixedUpdate()
    {
        MoveCharacter();
    }

    protected void LateUpdate()
    {
        var normalized = direction.normalized;
        if (normalized != prevDirection)
        {
            DirectionChanged?.Invoke(normalized);
        }

        prevDirection = direction.normalized;
    }

    protected virtual void MoveCharacter()
    {
        var position = (Vector2)transform.position + Time.deltaTime * speed * direction.normalized;
        rigidBody.MovePosition(position);
    }
}
