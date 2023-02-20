using System;
using System.Threading;
using Pixelplacement;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    //Events
    [HideInInspector] 
    public UnityEvent<int> onAttack;

    //Public
    public BossController bossController;

    //Private
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private Vector2 _movement;
    private float _lastDashTime = -999f;
    private CancellationTokenSource _cancellationToken;
    
    
    private void Awake()
    {
        _playerModel = GetComponent<PlayerModel>();
        _playerView = GetComponent<PlayerView>();
        
        _playerModel.onAttack.AddListener(HandleAttack);
        _playerModel.onPlayerDeath.AddListener(HandlePlayerDeath);
        
        _playerView.InitializeHealthBar(_playerModel.health);
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
        if (Time.timeScale <= 0) return;
        
        // Handle movement input
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        _playerModel.Move(_movement);

        // Handle attacking input
        if (Input.GetKeyDown("space") && 
            _movement.magnitude != 0 && 
            Time.time > _lastDashTime + _playerModel.attackCooldown)
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
            HandleDamage();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        HandleDamage();   
    }

    private void HandleDamage()
    {
        _playerView.TakeDamage();
        _playerModel.TakeDamage(bossController.damage);
        _playerView.UpdateHealth(_playerModel.health);
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player Died");
        bossController.playerIsAlive = false;
        StateManager.Instance.OnGameFinished?.Invoke(false);
        Destroy(gameObject);
    }
}