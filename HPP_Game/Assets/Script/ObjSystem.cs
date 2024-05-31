using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSystem : MonoBehaviour
{
    Transform   PlayerPos;
    public bool IsInRange = false;
    public float RangeSize = 2f;

    private void Start()
    {
         PlayerPos = GameObject.Find("Player").GetComponent<Transform>();
    }


    private void Update()
    {
        InRange();
        
    }
   public void InRange()
    {
        Vector3 dis = PlayerPos.transform.position - transform.position;
        float d = dis.magnitude;
        if(d<=RangeSize)
        {
            IsInRange = true;
        }
        else if(d>=RangeSize)
        {
            IsInRange = false;
        }
        
    }
}
