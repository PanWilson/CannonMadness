using System.Collections;
using UnityEngine;

public class CameraFromAbove : MonoBehaviour
{

    public Camera cam;

    bool lerping = false;
    bool isUp = false;

    Vector3 defaultPosition;
    Quaternion defaultRotation;

    private void Start()
    {
        defaultPosition = cam.transform.position;
        defaultRotation = cam.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GoUp();
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            GoDown();
        }
    }

    public void GoUp()
    {
        if (!lerping && !isUp)
        {
            isUp = true;

            defaultPosition = cam.transform.position;
            defaultRotation = cam.transform.rotation;

            StartCoroutine(Transition(transform.position, transform.rotation, 1f));
        }
    }

    public void GoDown()
    {
        if (!lerping)
        {
            isUp = false;
            StartCoroutine(Transition(defaultPosition, defaultRotation, 1f));
        }
    }

    IEnumerator Transition(Vector3 position, Quaternion rotation, float transitionTime)
    {
        lerping = true;
        float lerp = 0;

        Vector3 startinPosition = cam.transform.position;
        Quaternion startingRotation = cam.transform.rotation;

        while (lerp <= transitionTime)
        {
            lerp += Time.unscaledDeltaTime;
            float frac = Mathf.Clamp01(lerp / transitionTime);

            cam.transform.position = Vector3.Lerp(startinPosition, position, frac);
            cam.transform.rotation = Quaternion.Lerp(startingRotation, rotation, frac);

            yield return null;
        }

        lerping = false;
    }
}