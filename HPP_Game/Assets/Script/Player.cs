using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    

    //변수 선언

    public float MoveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator myAnim;
    public PlayerState PlayerStates = new PlayerState();
    private Table table;




    private void Update()
    {
        SetIsSit();


        if (Input.GetKeyDown(KeyCode.Space) && PlayerStates.IsSit)
        {
            PlayerStates.IsSit = false;
            MoveSpeed = 300f;
        }
        

    }
    private void Start()
    {
        table = FindObjectOfType<Table>();
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
        MoveAnim();
       

        
    }

    private void Move()
    {

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * Time.deltaTime * MoveSpeed ;
        //float hor = input.getaxisraw("horizontal");
        //float var = input.getaxisraw("vertical");
        //vector3 movevector = new vector3(hor, var).normalized;
        //transform.position += movespeed * movevector * time.deltatime;
        //debug.log(rb.velocity);

    }
    public void SetSit()
    {
       PlayerStates.IsSit = true;

    }
    public void SetIsSit()
    {
        if(PlayerStates.IsSit == true)
        {
            MoveSpeed = 0f;
            transform.position = table.transform.position;
        }

          
    }
    

    public void MoveAnim()
    {
        myAnim.SetFloat("moveX", rb.velocity.x);
        myAnim.SetFloat("moveY",rb.velocity.y);
        if(Input.GetAxisRaw("Horizontal") == 1 | Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
        }
    }
    

}
