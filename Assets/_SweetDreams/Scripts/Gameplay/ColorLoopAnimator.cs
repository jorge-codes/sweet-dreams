using UnityEngine;

// TODO: rethink this class to improve abstraction
// The same thing is done in FrameLoopAnimator.cs and it's
// possible that this can be improved further

public class ColorLoopAnimator : MonoBehaviour
{
    [SerializeField] private float delay = 0f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [Space(4), Header("Color List")]
    [SerializeField]
    private Color[] colors;
    private float delta = 0f;
    private float timer = 0f;
    private int index = 0;

    private void Awake()
    {
        const float seconds = 1f;
        delta = seconds / speed;
        timer -= delay;
    }

    private void Update()
    {
        // TODO: rethink this formula (same for FrameLoopAnimator.cs)
        // there is a way to do this with x mod y

        timer += Time.deltaTime;
        if (timer > delta)
        {
            index += 1;
            index = index >= colors.Length ? 0 : index;
            timer -= delta;
        }
        spriteRenderer.color = colors[index];

    }
}
