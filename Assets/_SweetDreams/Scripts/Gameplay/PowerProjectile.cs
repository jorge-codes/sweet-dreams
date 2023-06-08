using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PowerProjectile : MonoBehaviour
{
    [SerializeField] private PlayerController player = null;
    
    private void OnEnable()
    {
        player.CharacterAttacked += OnCharacterAttacked;
    }

    private void OnDisable()
    {
        player.CharacterAttacked -= OnCharacterAttacked;
    }

    private void OnCharacterAttacked(Vector2 direction)
    {
        // TODO: implement projectile
        print("PLAYER SHOT!!!!");
    }
}
