using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum UiBehaviour
{
    Full,
    ChangeSelectNode,
    AddItem,
}

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public delegate void InventoryUiUpdateCallback(Inventory ui, params UiBehaviour[] behave);
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
                InventoryUiUpdate.Invoke(this, UiBehaviour.AddItem);
                return;
            }
        }

        InventoryUiUpdate.Invoke(this, UiBehaviour.Full);
    }


    private void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedNode = inventory[0];
            InventoryUiUpdate.Invoke(this, UiBehaviour.ChangeSelectNode);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedNode = inventory[1];
            InventoryUiUpdate.Invoke(this, UiBehaviour.ChangeSelectNode);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedNode = inventory[2];
            InventoryUiUpdate.Invoke(this, UiBehaviour.ChangeSelectNode);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedNode = inventory[3];
            InventoryUiUpdate.Invoke(this, UiBehaviour.ChangeSelectNode);
        }

    }

    private void Update()
    {
        
    }

}
