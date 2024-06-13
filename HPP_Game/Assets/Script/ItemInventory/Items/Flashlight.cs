using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : Item
{
    GameObject plr;
    Light2D light;
    public Flashlight()
    {
        itemName = "Flashlight";
        description = "It will brighten the building";
        image = Resources.Load<Texture2D>("Texture/Flashlight");

        plr = GameObject.FindWithTag("Player");
        
        light = PoolManager.Instance.GetPool("LightModule", plr.transform.position, Quaternion.identity).GetComponent<Light2D>();
        light.transform.parent = plr.transform;
        light.gameObject.SetActive(false);
    }

    public override void OnEquipped()
    {
        base.OnEquipped();
        light.gameObject.SetActive(true);
        
    }

    public override void OnUpdated()
    {
        base.OnUpdated();
        Vector2 deltaPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - light.transform.position;
        float angle = Mathf.Atan2(deltaPos.y, deltaPos.x) * Mathf.Rad2Deg;
        light.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    public override void OnUnEquipped()
    {
        base.OnUnEquipped();
        light.gameObject.SetActive(false);
        
    }
}
