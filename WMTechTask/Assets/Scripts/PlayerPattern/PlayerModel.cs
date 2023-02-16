using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    //public 
    public float moveSpeed;
    public float dashDistance;
    public LayerMask obstacleLayer;

    public void Attack(Vector3 movement)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, dashDistance * Time.fixedDeltaTime, obstacleLayer);
        Debug.DrawRay(transform.position, movement * dashDistance * Time.fixedDeltaTime, Color.red, 3f);
        transform.position += movement * dashDistance * Time.fixedDeltaTime;

        if (hit.collider != null)
        {
            Debug.Log($"{hit.collider.gameObject.name}");
        }
    }

    public void Move(Vector3 movement)
    {
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
