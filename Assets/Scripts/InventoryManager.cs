using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour 
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item) 
    {
        items.Add(item);
        UpdateInventoryUI();
    }

    public void RemoveItem(Item item) 
    {
        items.Remove(item);
        UpdateInventoryUI();
    }

    void UpdateInventoryUI() 
    {
        // Code to update the UI when inventory changes
    }
}
