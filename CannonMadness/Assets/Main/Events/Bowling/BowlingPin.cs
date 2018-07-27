using UnityEngine;

public class BowlingPin : MonoBehaviour {

    public bool standing = true;

    Vector3 rotation;

    private void Update()
    {
        Quaternion rot = transform.rotation;
        rot.x = Mathf.Abs(rot.x);
        rot.y = 0;
        rot.z = Mathf.Abs(rot.z);

        if (rot.eulerAngles.magnitude > 25 && standing)
        {
            standing = false;
            OnFall();
        }
    }

    void OnFall()
    {
        transform.parent.GetComponent<Event>().CheckForCompletion();
    }

}
