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
        GetComponent<Interaction>().AddInteraction(Interact, KeyCode.F, "¾É±â", int.MaxValue, 1);
    }
    private void Update()
    {

    }
    void Interact()
    {
        player = FindObjectOfType<Player>();
        player.SetSit();
    }


}
