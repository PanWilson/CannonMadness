using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform teleportExit;
    public Transform exitTarget;
    public float transferAnimTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform player = other.transform.parent;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            Transfer(player, rb);
        } else if(other.GetComponent<Rigidbody>() != null)
        {
            Transform t = other.transform;
            Rigidbody rb = t.GetComponent<Rigidbody>();
            Transfer(t, rb);
        }
    }

    void Transfer(Transform t, Rigidbody rb)
    {
        StartCoroutine(TransferAnim(t, transferAnimTime));

        t.position = teleportExit.position;
        exitTarget.localPosition = transform.InverseTransformDirection(rb.velocity);
        t.LookAt(exitTarget);

        Vector3 exitDirection = exitTarget.position - teleportExit.position;
        Vector3 exitVelocity = exitDirection.normalized * rb.velocity.magnitude;

        rb.velocity = exitVelocity;
    }

    IEnumerator TransferAnim(Transform objectToAnim, float time)
    {
        Vector3 normalScale = objectToAnim.localScale;
        Vector3 smallScale = Vector3.one * 0.01f;

        objectToAnim.localScale = smallScale;

        float t = 0;
        while (t <= time)
        {
            t += Time.deltaTime;
            float f = Mathf.Clamp01(t / time);
            objectToAnim.localScale = Vector3.Lerp(smallScale, normalScale, f);
            yield return null;
        }
    }

}
