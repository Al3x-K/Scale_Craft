using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventoryManager : MonoBehaviour 
{
    public List<InventoryItem> items; // List of items to add to the inventory
    public GameObject itemButtonPrefab; // Button prefab with Image and Button components
    public Transform inventoryPanel; // Reference to the UI panel where buttons will be placed

    private void Start()
    {
        foreach (var item in items)
        {
            AddItemToInventory(item);
        }
    }

    private void AddItemToInventory(InventoryItem item)
    {
        GameObject button = Instantiate(itemButtonPrefab, inventoryPanel);
        button.GetComponent<Image>().sprite = item.itemIcon;
        button.GetComponent<Button>().onClick.AddListener(() => OnItemClicked(item));
    }

    private void OnItemClicked(InventoryItem item)
    {
        // Instantiate the 3D model at position (0,0,0)
        GameObject instantiatedObject = Instantiate(item.itemPrefab, Vector3.zero, Quaternion.identity);
        instantiatedObject.name = item.itemName;

        // Enable moving and scaling the instantiated object
        instantiatedObject.AddComponent<Draggable>();
        instantiatedObject.AddComponent<Scalable>();
    }
}
