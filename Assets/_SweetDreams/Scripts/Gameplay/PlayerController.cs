using UnityEngine;

public class PlayerController : CharacterFree
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        GetInputFromPlayer();
    }

    // TODO: Change function name because it handles input only
    private void GetInputFromPlayer()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
    }
    
}
