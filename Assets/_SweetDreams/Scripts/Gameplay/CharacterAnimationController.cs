using UnityEngine;

[RequireComponent(typeof(CharacterFree))]
public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Sprite imgPrimary = null;
    [SerializeField] private Sprite imgDown = null;
    [SerializeField] private Sprite imgSide = null;
    [SerializeField] private Sprite imgUp = null;

    [Space(20), Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private Animator animator = null;
    private CharacterFree character = null;

    private void Awake()
    {
        character = !character ? GetComponent<CharacterFree>() : character;
        animator = !animator ? GetComponent<Animator>() : animator;
        
        spriteRenderer.sprite = imgPrimary;
    }

    private void OnEnable()
    {
        character.DirectionChanged += OnDirectionChanged;
    }

    private void OnDisable()
    {
        character.DirectionChanged -= OnDirectionChanged;
    }

    protected virtual void OnDirectionChanged(Vector2 direction)
    {
        Debug.Log(direction);
        if (animator)
            RunDynamicAnimation(direction);
        else
            RunStaticAnimation(direction);
    }

    protected void RunStaticAnimation(Vector2 direction)
    {
        // if (direction == Vector2.zero) spriteRenderer.sprite = imgPrimary;
        // spriteRenderer.flipX = false;
        
        switch (direction)
        {
            case Vector2 v when v.Equals(Vector2.left):
                spriteRenderer.sprite = imgSide;
                spriteRenderer.flipX = true;
                break;
            case Vector2 v when v.Equals(Vector2.right):
                spriteRenderer.sprite = imgSide;
                spriteRenderer.flipX = false;
                break;
            case Vector2 v when v.Equals(Vector2.down):
                spriteRenderer.sprite = imgDown;
                break;
            case Vector2 v when v.Equals(Vector2.up):
                spriteRenderer.sprite = imgUp;
                break;
        }
    }

    protected void RunDynamicAnimation(Vector2 direction)
    {
        
    }
    
}
