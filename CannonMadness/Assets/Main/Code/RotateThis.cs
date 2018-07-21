using UnityEngine;

public class RotateThis : MonoBehaviour {

    public bool rotate;

    [Space]
    public float speed;

    [Header("Axis ammount")]
    [Range(0f,1f)] public float x = 0f;
    [Range(0f, 1f)] public float y = 0f;
    [Range(0f, 1f)] public float z = 0f;

    private void Update()
    {
        if (rotate)
        {
            Vector3 rotation = new Vector3(x, y, z) * speed * Time.deltaTime;
            transform.Rotate(rotation);
        }
    }

}
