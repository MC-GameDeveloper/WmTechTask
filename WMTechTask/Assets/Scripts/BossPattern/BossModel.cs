using System;
using UnityEngine;
using UnityEngine.Events;

public class BossModel : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<PhaseState> onPhaseChange;
    [HideInInspector]
    public UnityEvent onBossDeath;
    public int health;
    public float speed;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = health;
    }

    public enum PhaseState
    {
        PhaseOne,
        PhaseTwo,
        PhaseThree
    }
    public PhaseState currentState;
    
    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        
        if (_currentHealth > health * 0.6f)
        {
            PhaseChange(PhaseState.PhaseOne);
        }
        else if(_currentHealth > health * 0.3f)
        {
            PhaseChange(PhaseState.PhaseTwo);
        }
        else if (_currentHealth > 0)
        {
            PhaseChange(PhaseState.PhaseThree);
        }
        else
        {
            onBossDeath?.Invoke();
        }
        
        Debug.Log($"Boss Health: {_currentHealth}");
    }

    private void PhaseChange(PhaseState newPhase)
    {
        currentState = newPhase;
        onPhaseChange?.Invoke(currentState);
    }
}

