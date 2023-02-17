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
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;
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
    
    
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        foreach (var phase in phases)
        {
            if (currentHealth <= phase.healthThreshold)
            {
                PhaseChange(phase.phaseState);
            }
        }

        if (currentHealth <= 0)
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

