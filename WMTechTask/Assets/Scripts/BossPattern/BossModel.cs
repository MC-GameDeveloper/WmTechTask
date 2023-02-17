using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossModel : MonoBehaviour
{
    //events
    [HideInInspector]
    public UnityEvent<PhaseState> onPhaseChange;
    [HideInInspector]
    public UnityEvent onBossDeath;
    
    //public
    public int health;
    public float speed;
    public List<BossPhase> phases;
    public int damage = 3;
    public enum PhaseState
    {
        PhaseOne,
        PhaseTwo,
        PhaseThree
    }
    [HideInInspector]
    public PhaseState currentState;
    
    //private 
    private int _currentHealth;
    
    private void Awake()
    {
        _currentHealth = health;
    }
    
    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        foreach (var phase in phases)
        {
            if (_currentHealth <= phase.healthThreshold)
            {
                PhaseChange(phase.phaseState);
            }
        }

        if (_currentHealth <= 0)
        {
            onBossDeath?.Invoke();
        }
        
        Debug.Log($"MTC: {_currentHealth}, {currentState}");
    }

    private void PhaseChange(PhaseState newPhase)
    {
        currentState = newPhase;
        onPhaseChange?.Invoke(currentState);
    }
}

