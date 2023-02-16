using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    //public 
    public float moveSpeed;
    public float dashDistance;
    
    
    //private
    private Rigidbody2D _rb;

    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Attack(Vector3 movement)
    {
        transform.position += movement * dashDistance * Time.deltaTime;
    }

    public void Move(Vector3 movement)
    {
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
