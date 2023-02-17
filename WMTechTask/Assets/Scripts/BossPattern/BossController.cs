using System;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //public
    public PlayerController playerController;
    public List<GameObject> spikes;
    [HideInInspector]
    public int damage;
    
    //private
    private BossModel _bossModel;
    private BossView _bossView;
    private bool _playerIsAlive = true;
    private Quaternion _desiredRotation;

    private void Awake()
    {
        _bossModel = GetComponent<BossModel>();
        _bossView = GetComponent<BossView>();
        
        damage = _bossModel.damage;
        
        _bossModel.onBossDeath.AddListener(HandleBossDeath);
        _bossModel.onPhaseChange.AddListener(HandlePhaseChange);
        
        playerController.onAttack.AddListener(HandleAttack);
        playerController.onPlayerDeath.AddListener(HandlePlayerDeath);

        for (int i = 0; i < spikes.Count; i++)
        {
            if (i == 0)
            {
                spikes[i].SetActive(true);
            }
            else
            {
                spikes[i].SetActive(false);
            }
        }
        
        _bossView.InitializeHealthBar(_bossModel.maxHealth);
    }

    private void OnDestroy()
    {        
        _bossModel.onBossDeath.RemoveListener(HandleBossDeath);
        _bossModel.onPhaseChange.RemoveListener(HandlePhaseChange);
        
        playerController.onAttack.RemoveListener(HandleAttack);
        playerController.onPlayerDeath.RemoveListener(HandlePlayerDeath);
    }

    private void HandleAttack(int dmg)
    {
        _bossView.TakeDamage();
        _bossModel.TakeDamage(dmg);
        _bossView.UpdateHealth(_bossModel.currentHealth);
    }

    private void HandlePhaseChange(BossModel.PhaseState phase)
    {
        switch (phase)
        {
            case BossModel.PhaseState.PhaseOne:
                spikes[0]?.SetActive(true);
                break;
            case BossModel.PhaseState.PhaseTwo:
                spikes[1]?.SetActive(true);
                break;
            case BossModel.PhaseState.PhaseThree: 
                spikes[2]?.SetActive(true);
                break;
            default:
                Debug.LogError($"{_bossModel.currentState} is not a State");
                break;
        }
    }

    private void HandleBossDeath()
    {
        Debug.Log("Boss Died");
        Destroy(gameObject);
    }

    private void HandlePlayerDeath()
    {
        _playerIsAlive = false;
    }
    
    public void Update()
    {
        if (!_playerIsAlive) return;
        
        //make boss look at player
        Vector3 playerDir = playerController.transform.position - transform.position;
        playerDir.z = 0.0f;
        Quaternion targetRotation = Quaternion.FromToRotation(-Vector3.up, playerDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _bossModel.speed);

        if (_bossModel.currentState == BossModel.PhaseState.PhaseThree)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerController.transform.position, _bossModel.speed * 1.5f * Time.deltaTime);
        }
    }

    void LateUpdate()
    {
        // Update the boss view based on the current state of the boss model
        // For example, if the boss's health has changed, call bossView.UpdateHealth(bossModel.health)
        // If the boss is attacking, call bossView.StartAttack() and bossModel.EndAttack() when the attack is over
    }
}