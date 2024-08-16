using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour 
{
    public GameObject itemPrefab; 
    public int itemCount = 10; 

    void Start() 
    {
        PopulateGrid();
    }

    void PopulateGrid() 
    {
        for (int i = 0; i < itemCount; i++) 
        {
            GameObject item = Instantiate(itemPrefab, transform); 
        }
    }
}
