using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Table : ObjSystem
{

    private Player player;


    private void Start()
    {
        
    }
    private void Update()
    {
        InRange();
        Interact();
    }
    void Interact()
    {
        if(IsInRange && Input.GetKeyUp(KeyCode.F))
        {
            player = FindObjectOfType<Player>();
            player.SetSit();
        }
    }


}
