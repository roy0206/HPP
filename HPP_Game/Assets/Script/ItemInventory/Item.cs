using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public bool only = false;
    public Texture2D image;
    public string itemName;
    public string description;

    public virtual void OnEquipped()
    {

    }

    public virtual void OnUnEquipped()
    {

    }


    


}
