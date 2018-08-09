using UnityEngine;

[System.Serializable]
public struct MinMaxValue
{
    public float min, max;

    MinMaxValue(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}

public enum InputMethod
{
    Buttons,
    Mouse
}

public class CameraRotation : MonoBehaviour
{

    public static Vector3 cameraDirection;

    [Range(0.5f, 2.5f)] public float speed = 2;

    public GameObject target;
    public Camera cam;


    public InputMethod inputMethod;

    public MinMaxValue horizontalAngleBoundries;

    Vector3 rotation;
    Vector3 mouseStart;
    Vector3 lastRotation;

    private void Start()
    {
        rotation = transform.eulerAngles;
    }

    private void Update()
    {
        CameraManagement();

        if (inputMethod == InputMethod.Buttons)
        {
            RotateWithButtons();
        }
        else if (inputMethod == InputMethod.Mouse)
        {
            RotateWithMouse();
        }
    }

    private void CameraManagement()
    {
        cameraDirection = Vector3.Normalize(target.transform.position - cam.transform.position);

        transform.position = target.transform.position;
        cam.transform.LookAt(target.transform);

        // Making sure that camera will not rotate more than x value of an angle
        rotation.x = Mathf.Clamp(rotation.x, horizontalAngleBoundries.min, horizontalAngleBoundries.max);

        transform.eulerAngles = rotation;
    }

    private void RotateWithButtons()
    {
        Vector3 rotateDirection = new Vector3(Input.GetAxisRaw("Vertical"), -Input.GetAxisRaw("Horizontal"), 0);
        rotation = rotation + rotateDirection * speed * 180 * Time.deltaTime;
    }

    private void RotateWithMouse()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            mouseStart = Input.mousePosition;
            lastRotation = rotation; // Keeping track of current rotation before it will change
        }

        if (Input.GetButton("Fire1"))
        {
            Vector3 mouseDistance = Input.mousePosition - mouseStart;
            Vector3 rotateDirection = new Vector3(-mouseDistance.normalized.y, mouseDistance.normalized.x, 0);
            // Adding valueu to last rotation based on distance of the cursor * speed
            rotation = lastRotation + rotateDirection * mouseDistance.magnitude * speed;
        }
    }
}
