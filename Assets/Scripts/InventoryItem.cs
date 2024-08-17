using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public float weight;
    public float durability;
    public GameObject itemPrefab; // Prefab for the 3D model
}
