using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    public Key()
    {
        itemName = "Key";
        description = "Key to open iron door";
        image = Resources.Load<Texture2D>("Texture/Key");
    }

    public override void OnEquipped()
    {
        base.OnEquipped();

        Debug.Log("Key has equipped");
    }

    public override void OnUnEquipped()
    {
        base.OnUnEquipped();

        Debug.Log("Key has unequipped");
    }

    private int keyNum;
    public int KeyNum { get => keyNum; set => keyNum = value; }
}
