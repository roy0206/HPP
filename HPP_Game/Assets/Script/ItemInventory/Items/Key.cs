using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    public Key()
    {
        itemName = "Key";
        description = "Key to open iron door";
        image = Resources.Load("Assets/Resourses/Texture/TextTexture.png") as Texture2D;
    }

    private int keyNum;
    public int KeyNum { get => keyNum; set => keyNum = value; }
}
