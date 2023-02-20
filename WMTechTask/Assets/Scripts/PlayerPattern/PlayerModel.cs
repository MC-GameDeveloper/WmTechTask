using UnityEngine;
using UnityEngine.Events;

//This class manages player data
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
    public float attackCooldown = 1;


    private Vector2 _screenBoundaries;

    private void Start()
    {
        float height = 2f * Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        Vector3 topRight = new Vector3(Camera.main.transform.position.x + width / 2f, Camera.main.transform.position.y + height / 2f, Camera.main.transform.position.z);
        _screenBoundaries = Camera.main.ScreenToWorldPoint(topRight);
    }

    public void Attack(Vector3 movement)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, dashDistance * Time.fixedDeltaTime, obstacleLayer);
        Debug.DrawRay(transform.position, movement * dashDistance * Time.fixedDeltaTime, Color.red, 3f);
        
        transform.position += movement * dashDistance * Time.fixedDeltaTime;

        if (hit.collider != null)
        {
            onAttack?.Invoke(dmg, hit.collider.gameObject);
        }
    }

    public void Move(Vector3 movement)
    {
        transform.position += movement * moveSpeed * Time.deltaTime;
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_screenBoundaries.x, _screenBoundaries.x),
                                Mathf.Clamp(transform.position.y, -_screenBoundaries.y + 2, _screenBoundaries.y),
                                0);
    }
    
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            onPlayerDeath?.Invoke();
        }
    }
}
