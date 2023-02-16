using UnityEngine;

public class BossView : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public void UpdateHealth(int health)
    {
        // Update the boss's health bar or other visual elements
    }

    public void TakeDamage()
    {
        // Play a sound effect or animation when the boss takes damage
    }

    public void StartAttack()
    {
        // Play an attack animation or other visual effect
    }

    public void EndAttack()
    {
        // Stop the attack animation or other visual effect
    }
}