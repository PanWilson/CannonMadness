using UnityEngine;

public class CameraFreeLook : MonoBehaviour {

    [Range(1f,300f)]
    public float movementSpeed;
    [Range(1f, 300f)]
    public float mouseSpeed;

    [Range(1f, 5f)]
    public float sprintMultiplier;
    private float currentSprintMultiplier;

    [Range(0.01f, 1f)]
    public float slowMultiplier;
    private float currentSlowMultiplier;

    public Transform cameraObject;

    public KeyCode slow = KeyCode.LeftControl;
    public KeyCode sprint = KeyCode.LeftShift;
    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.Q;
    public KeyCode down = KeyCode.E;

    private void Awake()
    {
        currentSprintMultiplier = 1;
        currentSlowMultiplier = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(sprint))
        {
            currentSprintMultiplier = sprintMultiplier;
        } else if (Input.GetKeyUp(sprint))
        {
            currentSprintMultiplier = 1f;
        }

        if (Input.GetKeyDown(slow))
        {
            currentSlowMultiplier = slowMultiplier;
        }
        else if (Input.GetKeyUp(slow))
        {
            currentSlowMultiplier = 1f;
        }

        if (Input.GetKey(forward))
        {
            Move(Vector3.forward);
        }
        else if(Input.GetKey(back))
        {
            Move(Vector3.back);
        }

        if (Input.GetKey(right))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKey(left))
        {
            Move(Vector3.left);
        }

        if (Input.GetKey(up))
        {
            Move(Vector3.up);
        }
        else if (Input.GetKey(down))
        {
            Move(Vector3.down);
        }

        RotateAfterMouse();
    }

    void RotateAfterMouse()
    {
        float y = Input.GetAxisRaw("Mouse Y");
        float x = Input.GetAxisRaw("Mouse X");

        float posX = transform.rotation.eulerAngles.x - y * Time.unscaledDeltaTime * mouseSpeed;
        float posY = transform.rotation.eulerAngles.y + x * Time.unscaledDeltaTime * mouseSpeed;

        transform.rotation = Quaternion.Euler(posX, posY, 0);
    }

    void Move(Vector3 direction)
    {
        cameraObject.localPosition += direction * movementSpeed * Time.deltaTime * currentSprintMultiplier * currentSlowMultiplier;
        transform.position = cameraObject.position;
        cameraObject.localPosition = Vector3.zero;
    }

}
