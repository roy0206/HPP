using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Obj : ObjSystem
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
            Debug.Log("F downed");
        }
    }
    
    
}
