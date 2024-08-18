using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera frontCamera;
    public Camera sideCamera;
    public Camera topCamera;
    public Camera backCamera;
    public Camera otherSideCamera;
    
    void Start()
    {
        SetActiveCamera(frontCamera);  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveCamera(frontCamera);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveCamera(sideCamera);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveCamera(topCamera);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetActiveCamera(backCamera);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetActiveCamera(otherSideCamera);
        }
    }

    void SetActiveCamera(Camera activeCamera)
    {
        frontCamera.gameObject.SetActive(false);
        sideCamera.gameObject.SetActive(false);
        topCamera.gameObject.SetActive(false);
        backCamera.gameObject.SetActive(false);
        otherSideCamera.gameObject.SetActive(false);
    
        activeCamera.gameObject.SetActive(true);
    }
}
