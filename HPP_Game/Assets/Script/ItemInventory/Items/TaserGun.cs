using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TaserGun : Item
{
    VisualElement aimUi;
    float curTime = 0;

    public TaserGun()
    {
        itemName = "TaserGun";
        description = "Shoot it to stun police";
        image = Resources.Load<Texture2D>("Texture/TaserGun");

        aimUi = DynamicUiController.Instance.Root.Q<VisualElement>("Aim");
        aimUi.style.display = DisplayStyle.None;
    }

    public override void OnEquipped()
    {
        base.OnEquipped();

        aimUi.style.display = DisplayStyle.Flex;
    }

    public override void OnUpdated()
    {
        base.OnUpdated();

        if (aimUi.style.display == DisplayStyle.Flex)
        {
            Vector3 worldPos = Input.mousePosition * (1080 / Screen.height);
            aimUi.style.left = worldPos.x - (aimUi.layout.width / 2);
            aimUi.style.top = (1080 - worldPos.y) - 30;
        }

        curTime -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && curTime <= 0)
        {
            Debug.Log("Shoot");
            curTime = 3;

            GameObject player = GameObject.FindWithTag("Player");
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;

            GameObject bullet = PoolManager.Instance.GetPool("Bullet", player.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 1000);
        }
    }

    public override void OnUnEquipped()
    {
        base.OnUnEquipped();

        aimUi.style.display = DisplayStyle.None;
    }
}
