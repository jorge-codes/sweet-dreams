using System;
using UnityEngine;

public class PlayerController : CharacterFree
{
    public event Action<Vector2> CharacterAttacked;
    
    [SerializeField] private bool isMovable = true;
    [SerializeField] private bool isEmpowered = true;
    [SerializeField, Range(0.2f, 3f)] private float powerCooldownTime = 0.4f;
    private float timer;
    
    public bool IsMovable => isMovable;
    public bool IsEmpowered => isEmpowered;

    public void SetMobility(bool move)
    {
        isMovable = move;
    }

    public void SetPower(bool power)
    {
        isEmpowered = power;
    }

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        HandleInputMovement();
        HandleInputAttack();
    }

    private void HandleInputMovement()
    {
        if (!isMovable) return;
        
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
    }

    private void HandleInputAttack()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0f, float.MaxValue);

        if (isEmpowered && timer == 0f && Input.GetButtonDown("Jump"))
        {
            CharacterAttacked?.Invoke(direction);
            timer = powerCooldownTime;
        }
    }
    
}
