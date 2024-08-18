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

    private Rigidbody rb;

    public float moveSpeed = 5.0f;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.isKinematic = true; 
        rb.useGravity = false;  
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
            Vector3 moveDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += Vector3.forward;  
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection += Vector3.back;  
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection += Vector3.left;  
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection += Vector3.right;  
            }

            if (Input.GetKey(KeyCode.F))
            {
                moveDirection += Vector3.up;  
            }
            if (Input.GetKey(KeyCode.G))
            {
                if (!IsGrounded())
                {
                    moveDirection += Vector3.down;  
                }
            }

            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.up, 100 * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up, -100 * Time.deltaTime, Space.World);
            }

            Vector3 scaleChange = Vector3.one * 20 * Time.deltaTime;

            if (Input.GetKey(KeyCode.R))
            {
                Debug.Log("Scaling up: " + transform.localScale);
                transform.localScale += scaleChange;
                Debug.Log("New Scale: " + transform.localScale);
            }
            if (Input.GetKey(KeyCode.T))
            {
                Debug.Log("Scaling down: " + transform.localScale);
                
                if (transform.localScale.x > scaleChange.x && transform.localScale.y > scaleChange.y && transform.localScale.z > scaleChange.z)
                {
                    transform.localScale -= scaleChange;
                }
                else
                {
                    Debug.Log("Minimum scale reached, can't scale down further.");
                }
                Debug.Log("New Scale: " + transform.localScale);
            }

            
            if (Input.GetKeyDown(KeyCode.X))
            {
                DeleteObject();
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.1f);
    }

    public void Deselect()
    {
        if (currentlySelectedObject == this)
        {
            isSelected = false;
            objectRenderer.material.color = originalColor;
            currentlySelectedObject = null;  

            rb.isKinematic = false; 
            rb.useGravity = true;   
            Debug.Log("Rigidbody enabled, object should drop.");
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

    void OnCollisionEnter(Collision collision)
    {
        if (!isSelected && (collision.gameObject.CompareTag("Floor")))
        {
            rb.isKinematic = true; 
            rb.useGravity = false;  

            Debug.Log("Object has landed and is now unselectable.");
        }
    }
}
