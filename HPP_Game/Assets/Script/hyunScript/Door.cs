using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Door : ObjSystem
{
    GameObject player;
    private bool cnt = false;

    Interaction interaction;
    private void Update()
    {

    }
    private void Start()
    {
        player = GameObject.Find("Player");
        interaction = GetComponent<Interaction>();
        interaction.AddInteraction(Interact, KeyCode.F, "열기", int.MaxValue, 1);
    }

    void Interact()//interactions.Add((function, key, text, amount, hold));
    {
        Quaternion currentRotation = transform.rotation;

        interaction.RemoveAllInteraction();  
        if (cnt)
        {
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, -90);
            transform.rotation = newRotation;
            cnt = false;

            interaction.AddInteraction(Interact, KeyCode.F, "열기", int.MaxValue, 1);
        }
        else
        {
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 90);
            transform.rotation = newRotation;
            cnt = true;

            interaction.AddInteraction(Interact, KeyCode.F, "닫기", int.MaxValue, 1);
        }
    }
}
    