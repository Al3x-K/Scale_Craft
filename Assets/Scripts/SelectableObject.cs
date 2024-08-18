using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private bool isSelected = false;
    private static SelectableObject currentlySelectedObject = null;  
    private Renderer objectRenderer;
    private Color originalColor;
    public Color selectedColor = Color.yellow;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    void OnMouseDown()
    {
        if (currentlySelectedObject != null)
        {
            currentlySelectedObject.Deselect();  
        }

        currentlySelectedObject = this;
        isSelected = true;
        objectRenderer.material.color = selectedColor;

        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;

        Debug.Log("Object selected: " + gameObject.name);
    }

    void OnMouseUp()
    {
        isDragging = false;
        Debug.Log("Object deselected: " + gameObject.name);
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        }

        if (isSelected)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.up, 100 * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up, -100 * Time.deltaTime, Space.World);
            }

            Vector3 scaleChange = Vector3.one * 10 * Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("Scaling up");
                transform.localScale += scaleChange;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("Scaling down");
                if (transform.localScale.x > scaleChange.x && transform.localScale.y > scaleChange.y && transform.localScale.z > scaleChange.z)
                {
                    transform.localScale -= scaleChange;
                }
                else
                {
                    Debug.Log("Minimum scale reached, can't scale down further.");
                }
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                DeleteObject();
            }
        }
    }

    public void Deselect()
    {
        if (currentlySelectedObject == this)
        {
            isSelected = false;
            objectRenderer.material.color = originalColor;
            currentlySelectedObject = null;  
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    private void DeleteObject()
    {
        Debug.Log("Deleting object: " + gameObject.name);
        Destroy(gameObject);
    }
}
