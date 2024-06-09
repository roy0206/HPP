using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Door : ObjSystem
{
    GameObject player;
    private bool cnt = false;
    private void Update()
    {
        InRange();
        interact();
    }
    private void Start()
    {
        player = GameObject.Find("Player");

    }

    void interact()//interactions.Add((function, key, text, amount, hold));
    {
        if (IsInRange && Input.GetKeyDown(KeyCode.F))
        {
            Quaternion currentRotation = transform.rotation;

            
            if (cnt)
            {
                Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, -90);
                transform.rotation = newRotation;
                cnt = false;
            }
            else
            {
                Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 90);
                transform.rotation = newRotation;
                cnt = true;
            }
            
        }
    }
}
    