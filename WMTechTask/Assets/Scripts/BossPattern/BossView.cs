using System;
using UnityEngine;

public class BossView : MonoBehaviour
{
    [SerializeField] private AnimationCurve animCurve;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateHealth(int health)
    {
        // Update the boss's health bar or other visual elements
    }

    public void TakeDamage()
    {
        Debug.Log("playerView damage");
        Utilities.DamageAnimation(_spriteRenderer, animCurve);
    }
}