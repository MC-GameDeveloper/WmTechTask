using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    
    //Private
    [SerializeField] 
    private AnimationCurve animCurve;
    [SerializeField] 
    private Slider _healthBar;
    private TrailRenderer _dashTrail;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _dashTrail = GetComponent<TrailRenderer>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _dashTrail.emitting = false;
    }

    public void InitializeHealthBar(int health)
    {
        _healthBar.value = _healthBar.maxValue = health;
    }

    public async void Dash(CancellationTokenSource cancellationToken)
    {
        _dashTrail.emitting = true;
        await Task.Delay(TimeSpan.FromSeconds(_dashTrail.time), cancellationToken.Token);
        _dashTrail.emitting = false;
    }

    public void TakeDamage()
    {
        Utilities.DamageAnimation(_spriteRenderer, animCurve);
    }
    
    public void UpdateHealth(int health)
    {
        Debug.Log(health);
        _healthBar.value = health;
    }
}