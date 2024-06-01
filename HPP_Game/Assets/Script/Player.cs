using System.Collections;
using System.Collections.Generic;
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
    private Rigidbody2D     rb;
    public State PlayerState;
    private void Update()
    {

        Move();
        if (Input.GetKeyDown(KeyCode.Space) && PlayerState.IsSit)
        {
            Debug.Log("Is Sitting");
            PlayerState.IsSit = false;
            MoveSpeed = 5f;
        }
        PlayerStates();

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
    public void SetSit(bool isSit)
    {
        PlayerState.IsSit = isSit;
    }
    void PlayerStates()
    {
        if(PlayerState.IsSit)
        {
            MoveSpeed = 3f;
        }
        
    }
    

}
