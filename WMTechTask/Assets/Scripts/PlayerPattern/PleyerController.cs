using System;
using UnityEngine;

public class PleyerController : MonoBehaviour
{
    public float attackCooldown = 1;
    
    private PlayerModel _playerModel;
    private PlayerView _playerview;
    private Vector2 _movement;

    private float _lastDashTime = -999f;
    
    private Camera _camera;
    private void Start()
    {
        _playerModel = GetComponent<PlayerModel>();
        _playerview = GetComponent<PlayerView>();
        _camera = Camera.main;
    }
    
    private void Update()
    {
        // Handle movement input
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        _playerModel.Move(_movement);

        // Handle attacking input
        if (Input.GetKeyDown("space") && _movement.magnitude != 0)
        {
            if (Time.time < _lastDashTime + attackCooldown)
            {
                return;
            }
            
            _playerview.Dash(_movement, transform.position);
            _playerModel.Attack(_movement);
            _lastDashTime = Time.time;
        }
        
        //Handle look 
        var mp = Input.mousePosition;
        mp.z = 10;
        Vector3 mousePos = _camera.ScreenToWorldPoint(mp);
        
        Vector3 direction = mousePos - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = lookRotation;
    }
}