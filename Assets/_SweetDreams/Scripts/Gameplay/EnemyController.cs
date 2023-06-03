using UnityEngine;

public class EnemyController : CharacterFree
{
    [SerializeField] private float visionRange = 2f;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private PlayerController player = null;
    private bool isFollowPlayer;
    
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player == null) return;
        
        direction = player.transform.position - transform.position;
        var distance = direction.magnitude;
        direction.Normalize();
        isFollowPlayer = distance < visionRange;
    }
    

    protected override void MoveCharacter()
    {
        if (!isFollowPlayer) return;
        
        base.MoveCharacter();
    }
}
