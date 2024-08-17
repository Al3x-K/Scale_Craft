using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    CanvasGroup canvasGroup;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        itemBeingDragged = Instantiate(gameObject, transform.parent);  // Clone the item for dragging
        itemBeingDragged.transform.position = transform.position;
        startPosition = transform.position;
        startParent = transform.parent;
        canvasGroup = itemBeingDragged.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        itemBeingDragged.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
    if (itemBeingDragged.transform.parent == startParent) {
        Destroy(itemBeingDragged);  // Destroy the item if it's dragged out of the inventory
    } else {
        canvasGroup.blocksRaycasts = true;
    }
}
}
