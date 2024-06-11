using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public delegate void InventoryUiUpdateCallback(Inventory ui);
    public event InventoryUiUpdateCallback InventoryUiUpdate;

    private List<Node> inventory;
    public List<Node> InventoryList => inventory;

    private Node selectedNode;
    public Node SelectNode { get => selectedNode;}



    private void Awake()
    {
        Instance = this;
        inventory = new List<Node>()
        {
            new Node(), new Node(), new Node(), new Node()
        };
        selectedNode = inventory[0];

    }
    private void Start()
    {
        AddItem(new Key());
        AddItem(new TaserGun());
        AddItem(new Flashlight());
    }

    public Item FindItem(System.Type type)
    {
        var searchedNode = inventory.FindAll(node => node.item.GetType().Equals(type));
        if(searchedNode.Count > 1)
            Debug.LogWarning("There are many result for finding. The first has returned");
        if (searchedNode.Count == 0) return null;
        else return searchedNode[1].item;
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].item == null)
            {
                inventory[i].item = item;
                InventoryUiUpdate.Invoke(this);
                return;
            }
        }

        InventoryUiUpdate.Invoke(this);
    }

    KeyCode[] keys = new KeyCode[4]
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4
    };

    public bool isGetInput = false;
    private void ManageInput()
    {
        isGetInput = false;
        for (int i = 0; i < keys.Length; i++)
        {
            KeyCode key = keys[i];
            if (Input.GetKeyDown(key))
            {
                isGetInput = true;
                if (selectedNode != inventory[i])
                {
                    selectedNode.item?.OnUnEquipped();
                    selectedNode = inventory[i];
                    selectedNode.item?.OnEquipped();
                }

                InventoryUiUpdate.Invoke(this);
                break;
            }
        }
    }

    private void Update()
    {
        ManageInput();
        selectedNode.item.OnUpdated();
    }

}
