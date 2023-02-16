using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct BossPhaseStruct
{
    public int healthThreshold;
    public BossModel.PhaseState phaseState;
}

public class BossModel : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<PhaseState> onPhaseChange;
    [HideInInspector]
    public UnityEvent onBossDeath;
    public int health;
    public float speed;
    public List<BossPhaseStruct> phases;

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
    }

    private void PhaseChange(PhaseState newPhase)
    {
        currentState = newPhase;
        onPhaseChange?.Invoke(currentState);
    }
}

