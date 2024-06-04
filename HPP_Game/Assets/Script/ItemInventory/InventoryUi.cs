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

    private void Awake()
    {


        inventoryDocument = GetComponent<UIDocument>();
        frame = inventoryDocument.rootVisualElement;
        slots = new VisualElement[4]
        {
            frame.Q<VisualElement>("Slot1"),
            frame.Q<VisualElement>("Slot2"),
            frame.Q<VisualElement>("Slot3"),
            frame.Q<VisualElement>("Slot4")
        };
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
    }
}
