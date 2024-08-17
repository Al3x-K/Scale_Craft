using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour 
{
    private List<GameObject> itemsInInventory = new List<GameObject>();
    private bool isPointerOver = false;

    public void OnDrop(PointerEventData eventData) {
        GameObject draggedItem = DragHandler.itemBeingDragged;
        if (draggedItem != null && !itemsInInventory.Contains(draggedItem)) {
            AddItem(draggedItem);
        }
    }

    private void AddItem(GameObject item) {
        itemsInInventory.Add(item);
        item.transform.SetParent(transform, false);
        item.transform.position = transform.position;
        item.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isPointerOver = false;
    }

    public void RemoveItem(GameObject item) {
        if (itemsInInventory.Contains(item)) {
            itemsInInventory.Remove(item);
            Destroy(item);
        }
    }
}
