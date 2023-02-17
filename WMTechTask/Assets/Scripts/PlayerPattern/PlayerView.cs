using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private AnimationCurve animCurve;
    private TrailRenderer _dashTrail;
    
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _dashTrail = GetComponent<TrailRenderer>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _dashTrail.emitting = false;
    }

    public async void Dash(CancellationTokenSource cancellationToken)
    {
        _dashTrail.emitting = true;
        await Task.Delay(TimeSpan.FromSeconds(_dashTrail.time), cancellationToken.Token);
        _dashTrail.emitting = false;
    }

    public void TakeDamage()
    {
        Debug.Log("playerView damage");
        Utilities.DamageAnimation(_spriteRenderer, animCurve);
    }
    
    public void UpdateHealth(int health)
    {
        // Update the players' health bar or other visual elements
    }
}