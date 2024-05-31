using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float            MoveSpeed = 5f;
    private Rigidbody2D     rb;
    

    private void Update()
    {

        Move();


    }
    private void FixedUpdate()
    {
        
    }

    private void Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float var = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = new Vector3(hor, var).normalized;
        transform.position += MoveSpeed * moveVector * Time.deltaTime;

    }
    public void Is
}
