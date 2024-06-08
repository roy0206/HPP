using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSystem : MonoBehaviour
{
    public GameObject PlayerPos;
    public bool IsInRange = false;
    public float RangeSize = 2f;

    private void Start()
    {
    }


    private void Update()
    {
        InRange();

    }
    public void InRange()
    {
        if (PlayerPos != null)
        {
            Vector3 dis = PlayerPos.transform.position - transform.position;
            float d = dis.magnitude;
            if (d <= RangeSize)
            {
                IsInRange = true;
            }
            else if (d >= RangeSize)
            {
                IsInRange = false;
            }
        }

    }
}