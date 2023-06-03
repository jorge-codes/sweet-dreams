using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float visionRange = 2f;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Rigidbody2D rigidBody = null;
    [SerializeField] private PlayerController player = null;
    private Vector2 direction;
    private bool isFollowPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - transform.position;
        var distance = direction.magnitude;
        direction.Normalize();
        isFollowPlayer = distance < visionRange;
    }

    private void FixedUpdate()
    { 
        MoveCharacter();
    }
    
    private void MoveCharacter()
    {
        if (!isFollowPlayer) return;
        
        var position = (Vector2)transform.position + (Time.deltaTime * speed * direction); 
        rigidBody.MovePosition(position);
    }
}
