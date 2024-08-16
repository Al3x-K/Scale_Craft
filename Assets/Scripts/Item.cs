using UnityEngine;

[System.Serializable]
public class Item 
{
    public string itemName;
    public int id;
    public Sprite icon;

    public Item(string name, int itemId, Sprite itemIcon) 
    {
        itemName = name;
        id = itemId;
        icon = itemIcon;
    }
}
