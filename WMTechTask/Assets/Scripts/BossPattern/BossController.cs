using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossModel bossModel;
    public BossView bossView;

    void Update()
    {
        // Get input from the player and update the boss model
        // For example, if the player presses the attack button, call bossModel.StartAttack()
    }

    void LateUpdate()
    {
        // Update the boss view based on the current state of the boss model
        // For example, if the boss's health has changed, call bossView.UpdateHealth(bossModel.health)
        // If the boss is attacking, call bossView.StartAttack() and bossModel.EndAttack() when the attack is over
    }
}