using System;
using UnityEngine;

public class PlayerController : CharacterFree
{
    public event Action<Vector2> CharacterAttacked;

    [SerializeField] private bool isMovable = true;
    [SerializeField] private bool isEmpowered = true;
    [SerializeField, Range(0.2f, 3f)] private float powerCooldownTime = 0.4f;
    [SerializeField, Range(1f, 500f)] private float damageImpulse = 20f;
    private float timer;
    private bool isDamaged = false;
    private Vector2 repelDirection;
    
    public bool IsMovable => isMovable;
    public bool IsEmpowered => isEmpowered;

    public void SetMobility(bool move)
    {
        isMovable = move;
        velocity = Vector2.zero;
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
        
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        velocity.Normalize();
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

    protected override void MoveCharacter()
    {
        if (!isDamaged)
        {
            base.MoveCharacter();
            return;
        }

        isDamaged = false;
        rigidBody.AddForce(repelDirection * damageImpulse, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            var enemyPosition = col.gameObject.transform.position;
            repelDirection = (transform.position - enemyPosition).normalized;
            isDamaged = true;
            // rigidBody.AddForce(repelDirection * damageImpulse, ForceMode2D.Impulse);
        }
    }

}
