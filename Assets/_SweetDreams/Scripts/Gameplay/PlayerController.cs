using UnityEngine;

public class PlayerController : CharacterFree
{
    [SerializeField] private bool isMovable = true;
    public bool IsMovable => isMovable;

    public void SetMobility(bool move)
    {
        isMovable = move;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (!isMovable) return;
        
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
    }
    
}
