using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform teleportExit;
    public Transform exitTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform player = other.transform.parent;
            Rigidbody rb = player.GetComponent<Rigidbody>();

            player.position = teleportExit.position;
            exitTarget.localPosition = transform.InverseTransformDirection(rb.velocity);
            player.LookAt(exitTarget);

            Vector3 exitDirection = exitTarget.position - teleportExit.position;
            Vector3 exitVelocity = exitDirection.normalized * rb.velocity.magnitude;

            rb.velocity = exitVelocity;
        }
    }

}
