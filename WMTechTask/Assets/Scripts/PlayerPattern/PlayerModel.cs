using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : MonoBehaviour
{
    //events
    [HideInInspector]
    public UnityEvent<int, GameObject> onAttack;
    [HideInInspector]
    public UnityEvent onPlayerDeath;

    //public 
    public float moveSpeed;
    public float dashDistance;
    public LayerMask obstacleLayer;
    public int dmg = 10;
    public int health = 10;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Attack(Vector3 movement)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, dashDistance * Time.fixedDeltaTime, obstacleLayer);
        Debug.DrawRay(transform.position, movement * dashDistance * Time.fixedDeltaTime, Color.red, 3f);
        
        transform.position += movement * dashDistance * Time.fixedDeltaTime;

        if (hit.collider != null)
        {
            onAttack?.Invoke(dmg, hit.collider.gameObject);
            Debug.Log($"{hit.collider.gameObject.name}");
        }
    }

    public void Move(Vector3 movement)
    {
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        TakeDamage(3);
    }
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"Player Health = {health}");
        if (health <= 0)
        {
            onPlayerDeath?.Invoke();
        }
    }
}
