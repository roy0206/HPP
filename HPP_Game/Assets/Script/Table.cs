using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Table : ObjSystem
{
    

    private void Update()
    {
        InRange();
        Interact();
    }
    void Interact()
    {
        if(IsInRange && Input.GetKeyUp(KeyCode.F))
        {
           Player player = FindObjectOfType<Player>();
            if(player != null)
            {
                  player.SetSit(true);
            }
        }
    }
    
    
}