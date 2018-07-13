using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform teleportExit;
    public Transform exitDirection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform playerParent = other.transform.parent;
            Rigidbody rb = playerParent.GetComponent<Rigidbody>();
            playerParent.position = teleportExit.position;
            exitDirection.localPosition = rb.velocity.normalized;
            Vector3 oldVelocity = rb.velocity;
            Vector3 direction = exitDirection.position - teleportExit.position;
            Vector3 newVelocity = direction.normalized * oldVelocity.magnitude;
            rb.velocity = newVelocity;
        }
    }

}
