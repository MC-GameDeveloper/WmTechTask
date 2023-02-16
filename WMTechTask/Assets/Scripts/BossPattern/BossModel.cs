public class BossModel
{
    public int health;
    public int damage;
    public float speed;
    public bool isAttacking;
    public bool isAlive;

    public BossModel(int health, int damage, float speed)
    {
        this.health = health;
        this.damage = damage;
        this.speed = speed;
        isAttacking = false;
        isAlive = true;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            isAlive = false;
        }
    }

    public void StartAttack()
    {
        isAttacking = true;
    }

    public void EndAttack()
    {
        isAttacking = false;
    }

    // Other methods for controlling the boss's movement and attack patterns
}

