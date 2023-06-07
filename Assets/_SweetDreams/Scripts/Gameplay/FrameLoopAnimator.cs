using System;
using UnityEngine;

public class FrameLoopAnimator : MonoBehaviour
{
    [SerializeField] private float delay = 0f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [Space(4), Header("Sprite List")]
    [SerializeField] private Sprite[] sprites;
    private float delta = 0f;
    private float timer = 0f;
    private int index = 0;

    private void Awake()
    {
        const float seconds = 1f;
        delta = seconds / speed;
    }
    

    void Update()
    {
        // TODO: re-think this formula
        // there is a way to do this with x mod y
        // but I cannot solve it right now

        timer += Time.deltaTime;
        if (timer > delta)
        {
            index += 1;
            index = index >= sprites.Length ? 0 : index;
            timer -= delta;
        }
        spriteRenderer.sprite = sprites[index];


    }


}
