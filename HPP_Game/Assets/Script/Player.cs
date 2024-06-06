using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    public struct State // 플레이어 상태 구초체 선언
    {
        public bool IsSit;
    }

    //변수 선언

    public float MoveSpeed = 5f;
    private Rigidbody2D rb;
    public State PlayerState;
    private Animator myAnim;




    private void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Space) && PlayerState.IsSit)
        {
            Debug.Log("Is Sitting");
            PlayerState.IsSit = false;
            MoveSpeed = 300f;
        }
        PlayerStates();

    }
    private void Start()
    {
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
        /*float hor = Input.GetAxisRaw("Horizontal");
        float var = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = new Vector3(hor, var).normalized;
        transform.position += MoveSpeed * moveVector * Time.deltaTime;
        Debug.Log(rb.velocity);*/

    }
    public void SetSit(bool isSit)
    {
        PlayerState.IsSit = isSit;
    }
    void PlayerStates()
    {
        if(PlayerState.IsSit)
        {
            MoveSpeed = 150f;
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
