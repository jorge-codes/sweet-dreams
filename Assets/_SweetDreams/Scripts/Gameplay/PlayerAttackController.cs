using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 8f;
    [SerializeField] private PlayerController player = null;
    [SerializeField] private ProjectileController prefab = null;
    [SerializeField] private Transform mountPoint = null;
    [SerializeField] private Transform projectilesParent = null;
    private Vector2 projectileDirection;
    
    // TODO: refactor the data flow

    private void OnEnable()
    {
        player.CharacterAttacked += OnCharacterAttacked;
        player.LookDirectionChanged += OnLookingDirectionChanged;
    }

    private void OnDisable()
    {
        player.CharacterAttacked -= OnCharacterAttacked;
        player.LookDirectionChanged -= OnLookingDirectionChanged;
    }

    private void OnCharacterAttacked(Vector2 direction)
    {
        // TODO: refactor because direction is doing nothing
        var projectile = Instantiate(prefab, mountPoint.position, Quaternion.identity, projectilesParent);
        projectile.SetDirection(projectileDirection, projectileSpeed);
    }

    private void OnLookingDirectionChanged(Vector2 direction)
    {
        projectileDirection = direction;
    }
}
