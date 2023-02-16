using System;
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

    public async void Dash()
    {
        _dashTrail.emitting = true;
        await Task.Delay(TimeSpan.FromSeconds(_dashTrail.time));
        _dashTrail.emitting = false;
    }
    
    
    //TODO: leave in to show process
    // void OnDrawGizmos()
    // {
    //     Vector3 forward = transform.TransformDirection(Vector3.up) * 10;
    //     Debug.DrawRay(transform.position, forward, Color.green);
    // }
}