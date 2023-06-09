using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 8f;
    [SerializeField] private PlayerController player = null;
    [SerializeField] private ProjectileController prefab = null;
    [SerializeField] private Transform mountPoint = null;
    [SerializeField] private Transform projectilesParent = null;
    
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
        var projectile = Instantiate(prefab, mountPoint.position, Quaternion.identity, projectilesParent);
        projectile.SetDirection(direction, projectileSpeed);
    }
    
}
