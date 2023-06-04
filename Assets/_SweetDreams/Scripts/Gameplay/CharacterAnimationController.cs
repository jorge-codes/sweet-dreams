using UnityEngine;

public enum AnimationTrigger
{
    Direction, Movement
}

[RequireComponent(typeof(CharacterFree))]
public class CharacterAnimationController : MonoBehaviour
{
    private CharacterFree character = null;
    private Animator animator = null;

    [SerializeField] private AnimationTrigger animationTrigger;
    
    [Space(10), Header("Static Animation Settings")]
    [SerializeField] private SpriteRenderer spriteRenderer = null; 
    [SerializeField] private Sprite imgPrimary = null;
    [SerializeField] private Sprite imgDown = null;
    [SerializeField] private Sprite imgSide = null;
    [SerializeField] private Sprite imgUp = null;
    [SerializeField, Range(0.1f, 10f)] private float slopeThreshold = 2.5f;
    
    [Space(10), Header("Dynamic Animation Settings")]
    [SerializeField] private string triggerUp = "WalkUp";
    [SerializeField] private string triggerDown = "WalkDown";
    [SerializeField] private string triggerRight = "WalkRight";
    [SerializeField] private string triggerLeft = "WalkLeft";
    [SerializeField] private string triggerStop = "Stop";
    [SerializeField, Range(0.01f, 1f)] private float stopTime = 0.3f;
    
    private float timerStop = 0f;
    private bool isTimer = false;
    

    private void Awake()
    {
        character = !character ? GetComponent<CharacterFree>() : character;
        animator = !animator ? GetComponent<Animator>() : animator;
        
        spriteRenderer.sprite = imgPrimary;

        timerStop = stopTime;
    }

    private void OnEnable()
    {
        character.DirectionChanged += OnDirectionChanged;
        character.PositionChanged += OnPositionChanged;
    }

    private void OnDisable()
    {
        character.DirectionChanged -= OnDirectionChanged;
        character.PositionChanged -= OnPositionChanged;
    }

    private void Update()
    {
        if (!isTimer) return;

        timerStop -= Time.deltaTime;
        if (timerStop < 0f)
        {
            animator.SetTrigger(triggerStop);
            isTimer = false;
        }
        
    }

    protected virtual void OnPositionChanged(Vector2 direction)
    {
        if (animationTrigger == AnimationTrigger.Direction) return;
        
        if (animator && animator.enabled)
            RunDynamicAnimation(direction);
        else
            RunStaticAnimation(direction);
    }

    protected virtual void OnDirectionChanged(Vector2 direction)
    {
        if (animationTrigger == AnimationTrigger.Movement) return;
        
        if (animator && animator.enabled)
            RunDynamicAnimation(direction);
        else
            RunStaticAnimation(direction);
    }

    protected void RunStaticAnimation(Vector2 direction)
    {
        direction.Normalize();
        var slope = direction.x == 0f ? 1f : direction.y / direction.x;
        
        if (Mathf.Abs(slope) > slopeThreshold)
        {
            spriteRenderer.sprite = direction.y > 0f ? imgUp : imgDown;
        }
        else
        {
            spriteRenderer.sprite = imgSide;
            spriteRenderer.flipX = direction.x < 0f;
        }
        // if (slope <= slopeThreshold)
        // {
        //     spriteRenderer.sprite = imgSide;
        //     spriteRenderer.flipX = direction.x < 0f;
        // }
        // else
        // {
        //     spriteRenderer.sprite = direction.y < 0 ? imgUp : imgDown;
        // }
        // switch (direction)
        // {
        //     case Vector2 v when v.Equals(Vector2.left):
        //         spriteRenderer.sprite = imgSide;
        //         spriteRenderer.flipX = true;
        //         break;
        //     case Vector2 v when v.Equals(Vector2.right):
        //         spriteRenderer.sprite = imgSide;
        //         spriteRenderer.flipX = false;
        //         break;
        //     case Vector2 v when v.Equals(Vector2.down):
        //         spriteRenderer.sprite = imgDown;
        //         break;
        //     case Vector2 v when v.Equals(Vector2.up):
        //         spriteRenderer.sprite = imgUp;
        //         break;
        // }
    }

    protected void RunDynamicAnimation(Vector2 direction)
    {
        isTimer = false;
        switch (direction)
        {
            case Vector2 v when v.Equals(Vector2.left):
                animator.SetTrigger(triggerLeft);
                break;
            case Vector2 v when v.Equals(Vector2.right):
                animator.SetTrigger(triggerRight);
                break;
            case Vector2 v when v.Equals(Vector2.down):
                animator.SetTrigger(triggerDown);
                break;
            case Vector2 v when v.Equals(Vector2.up):
                animator.SetTrigger(triggerUp);
                break;
            case Vector2 v when v.Equals(Vector2.zero):
                timerStop = stopTime;
                isTimer = true;
                break;
        }
    }
    
}
