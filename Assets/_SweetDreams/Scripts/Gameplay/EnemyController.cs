using System;
using UnityEngine;

public class EnemyController : CharacterFree
{
    [SerializeField] private float visionRange = 2f;
    [SerializeField] private float coolDownAfterAttack = 4f;
    [SerializeField] private PlayerController player = null;
    private bool isFollowPlayer;
    private float timerCoolDownAfterAttack;
    
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        timerCoolDownAfterAttack = coolDownAfterAttack;
    }

    private void Update()
    {
        if (player == null) return;
        
        
        if (timerCoolDownAfterAttack < coolDownAfterAttack)
        {
            timerCoolDownAfterAttack += Time.deltaTime;
            velocity = Vector2.zero;
            return;
        }

        velocity = player.transform.position - transform.position;
        var distance = velocity.magnitude;
        velocity.Normalize();
        isFollowPlayer = distance < visionRange;
    }
    

    protected override void MoveCharacter()
    {
        if (!isFollowPlayer) return;
        
        base.MoveCharacter();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PowerPlayer"))
        {
            Kill();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            print("Enemy collision with Player");
            timerCoolDownAfterAttack = 0f;
        }
    }
}
