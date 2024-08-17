using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InventorySlot : MonoBehaviour, IDropHandler {
    private List<GameObject> itemsInSlot = new List<GameObject>();
    public float itemOffset = 70f; // Distance between items

    public void OnDrop(PointerEventData eventData) {
        GameObject draggedItem = DragHandler.itemBeingDragged;
        if (draggedItem != null) {
            RectTransform slotRect = GetComponent<RectTransform>();
            RectTransform itemRect = draggedItem.GetComponent<RectTransform>();

            // Calculate new position starting from the left edge of the slot
            float newXPosition = slotRect.rect.xMin + (itemsInSlot.Count * itemOffset) + (itemRect.rect.width / 2);
            Vector3 newPosition = new Vector3(newXPosition, slotRect.position.y, slotRect.position.z);

            // Set parent, position, and modify canvas group properties
            draggedItem.transform.SetParent(transform, false);
            draggedItem.transform.localPosition = new Vector3(newXPosition, 0, 0); // Local position to align within the slot
            itemRect.sizeDelta = new Vector2(100, 430);
            draggedItem.GetComponent<CanvasGroup>().blocksRaycasts = true;

            // Add the new item to the list
            itemsInSlot.Add(draggedItem);
        }
    }
}
