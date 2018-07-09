using UnityEngine;

public class RotateThis : MonoBehaviour {

    public bool rotate;
    public float rotationSpeed;

    private void Update()
    {
        if (rotate)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

}
