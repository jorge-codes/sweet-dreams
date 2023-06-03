using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rigidBody = null;
    private Vector2 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInputFromPlayer();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    // TODO: Change function name because it handles input only
    private void GetInputFromPlayer()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
    }

    private void MoveCharacter()
    {
        var position = (Vector2)transform.position + (Time.deltaTime * speed * direction); 
        rigidBody.MovePosition(position);
    }
}
