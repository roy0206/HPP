using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ObjSystem
{
    
    private void Update()
    {
        InRange();
    }

    void interact()
    {
        if (IsInRange && Input.GetKeyDown(KeyCode.F))
        {
            Player.transform.position += transform.position;
        }
    }
}
    