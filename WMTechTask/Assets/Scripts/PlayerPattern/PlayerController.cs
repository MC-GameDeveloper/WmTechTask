using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] 
    public UnityEvent<int> onAttack;

    public float attackCooldown = 1;

    public BossController bossController;
    
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private Vector2 _movement;

    private float _lastDashTime = -999f;

    private CancellationTokenSource _cancellationToken;
    
    private void Start()
    {
        _playerModel = GetComponent<PlayerModel>();
        _playerView = GetComponent<PlayerView>();
        
        _playerModel.onAttack.AddListener(HandleAttack);
        _playerModel.onPlayerDeath.AddListener(HandlePlayerDeath);
    }

    private void OnDestroy()
    {
        _playerModel.onAttack.RemoveListener(HandleAttack);
        _playerModel.onPlayerDeath.RemoveListener(HandlePlayerDeath);
        
        _cancellationToken?.Cancel();
        _cancellationToken?.Dispose();
    }

    private void Update()
    {
        // Handle movement input
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        _playerModel.Move(_movement);

        // Handle attacking input
        if (Input.GetKeyDown("space") && _movement.magnitude != 0 && Time.time > _lastDashTime + attackCooldown)
        {
            _cancellationToken?.Dispose();
            _cancellationToken = new CancellationTokenSource();
            _playerView.Dash(_cancellationToken);
            _playerModel.Attack(_movement);
            _lastDashTime = Time.time;
        }
    }

    private void HandleAttack(int dmg, GameObject other)
    {
        if (other.name == "Boss")
        {
            onAttack?.Invoke(dmg);
        }
        else
        {
            _playerModel.TakeDamage(bossController.damage);
        }
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player Died");
        Destroy(gameObject);
    }
}