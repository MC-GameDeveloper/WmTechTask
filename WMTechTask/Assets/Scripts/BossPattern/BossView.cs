using System;
using UnityEngine;
using UnityEngine.UI;

public class BossView : MonoBehaviour
{
    [SerializeField] Slider _healthBar;
    [SerializeField] private AnimationCurve animCurve;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void InitializeHealthBar(int health)
    {
        _healthBar.value = _healthBar.maxValue = health;
    }

    public void UpdateHealth(int health)
    {
        _healthBar.value = health;
    }

    public void TakeDamage()
    {
        Utilities.DamageAnimation(_spriteRenderer, animCurve);
    }
}