using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameplayView : MonoBehaviour
{
    [SerializeField] private float fadeTime = 0.4f;
    [SerializeField] private bool isBlackoutOnStart = true;
    [SerializeField] private Image imageBlackout = null;
    private float transparent = 0f;
    private float blackout = 1f;

    private void Awake()
    {
        DOTween.Init();
    }

    private void Start()
    {
        if (isBlackoutOnStart) imageBlackout.color = Color.black;
    }

    public void FadeIn()
    {
        Fade(transparent, fadeTime);
    }

    public void FadeOut()
    {
        Fade(blackout, fadeTime);
    }

    private void Fade(float target, float duration)
    {
        imageBlackout.DOFade(target, duration);
    }
}
