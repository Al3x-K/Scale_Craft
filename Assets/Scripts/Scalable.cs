using UnityEngine;

public class Scalable : MonoBehaviour
{
    private float scaleSpeed = 0.1f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
        }
    }
}
