using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private TrailRenderer _dashTrail;

    private void Start()
    {
        _dashTrail = GetComponent<TrailRenderer>();
        _dashTrail.emitting = false;
    }

    public async void Dash(CancellationTokenSource cancellationToken)
    {
        _dashTrail.emitting = true;
        await Task.Delay(TimeSpan.FromSeconds(_dashTrail.time), cancellationToken.Token);
        _dashTrail.emitting = false;
    }
}