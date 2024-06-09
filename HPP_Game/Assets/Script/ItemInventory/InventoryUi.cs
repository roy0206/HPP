using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUi : MonoBehaviour
{
    private UIDocument inventoryDocument;
    private VisualElement frame;
    private VisualElement[] slots;
    private Label title;
    private Label description;

    private void Awake()
    {


        inventoryDocument = GetComponent<UIDocument>();
        frame = inventoryDocument.rootVisualElement;
        title = frame.parent.Q<Label>("Title");
        description = frame.parent.Q<Label>("Description");

        title.style.display = DisplayStyle.None;
        description.style.display = DisplayStyle.None;

        slots = new VisualElement[4]
        {
            frame.Q<VisualElement>("Slot1"),
            frame.Q<VisualElement>("Slot2"),
            frame.Q<VisualElement>("Slot3"),
            frame.Q<VisualElement>("Slot4")
        };
        print(frame);
    }
    private void Start()
    {
        Inventory.Instance.InventoryUiUpdate += UpdateUi;
    }

    public void UpdateUi(Inventory inventory)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            var currentSlot = slots[i];

            if (inventory.InventoryList[i].item == null)
                currentSlot.style.backgroundImage = null;
            else
            {
                currentSlot.style.backgroundImage = inventory.InventoryList[i].item.image;
            }


            Color newColor = new Color(255,255,0);
            newColor.a = (inventory.SelectNode == inventory.InventoryList[i])? 1 : 0;

            currentSlot.style.borderTopColor
                = currentSlot.style.borderBottomColor
                = currentSlot.style.borderLeftColor
                = currentSlot.style.borderRightColor
                = newColor;

        }
        if (inventory.isGetInput)
        {
            StopAllCoroutines();
            title.style.display = DisplayStyle.None;
            description.style.display = DisplayStyle.None;
            if (inventory.SelectNode.item != null) 
                StartCoroutine(FadeText(inventory.SelectNode.item.itemName, inventory.SelectNode.item.description));
        }
        
    }

    IEnumerator FadeText(string s1, string s2)
    {
        title.style.display = DisplayStyle.Flex;
        description.style.display = DisplayStyle.Flex;

        title.text = s1;
        description.text = s2;

        Color newColor = new Color(0, 0, 0, 0);
        title.style.color = newColor;
        description.style.color = newColor;

        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            newColor = title.style.color.value;
            newColor.a += 0.1f;
            title.style.color = newColor;
            description.style.color = newColor;
        }

        yield return new WaitForSeconds(2);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            newColor = title.style.color.value;
            newColor.a -= 0.1f;
            title.style.color = newColor;
            description.style.color = newColor;
        }

        title.style.display = DisplayStyle.None;
        description.style.display = DisplayStyle.None;
    }
}
