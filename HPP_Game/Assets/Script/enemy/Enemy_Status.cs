using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Status : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    public bool isIdle, isFollow, isAttack;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnemyIdle()
    {

    }
    private void FollowPlayer()
    {
        
    }
    private void AttackPlayer()
    {

    }
}
