using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventoryManager : MonoBehaviour 
{
    public List<InventoryItem> items; 
    public GameObject itemButtonPrefab; 
    public Transform inventoryPanel; 

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

    
    }
}
