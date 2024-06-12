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
        Status((gameManager.player.transform.position - gameManager.enemy.transform.position).magnitude);
        if (isAttack)
        {
            AttackPlayer();
        }
        if (isFollow)
        {
            FollowPlayer();
        }
        else if (isIdle)
        {
            EnemyIdle();
        }
    }
    private void Status(float dist)
    {
        isAttack = (dist <= gameManager.AttackDist);//&&!isSitting
        isFollow = (dist <= gameManager.DetectDist);//&&!isSitting
        isIdle = (dist > gameManager.DetectDist);
    }
    private void EnemyIdle()
    {
        //교도관이 지켜야할곳으로 이동
        StopCoroutine("DelayFuntion");
    }
    private void FollowPlayer()
    {
        StartCoroutine("DelayFuntion", 0.2f);
    }
    private void AttackPlayer()
    {
        //StopCoroutine("DelayFuntion");
    }
    private IEnumerator DelayFuntion()
    {
        gameManager.PathFinding();
        print("1");
        yield return null;
    }
}
