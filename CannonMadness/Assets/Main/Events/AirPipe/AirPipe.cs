using UnityEngine;

public class AirPipe : MonoBehaviour {

    public Transform airTarget;
    public float power;
    private Vector3 direction;
    private bool playerInside;
    private Rigidbody rb;

    public void Awake()
    {
        direction = transform.position - airTarget.position;
        direction = direction.normalized;
    }

    private void Update()
    {
        if (playerInside && rb != null)
        {
            rb.AddForce(direction * power);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (rb == null)
                rb = other.transform.parent.GetComponent<Rigidbody>();
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

}
