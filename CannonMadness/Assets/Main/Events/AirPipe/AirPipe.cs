using UnityEngine;

public class AirPipe : MonoBehaviour {

    public bool active = true;
    [Range(1f, 100f)] public float force;

    private BoxCollider boxCollider;
    private const int forceMultiplier = 10;

    Vector3 pipeDirection;

    public void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        pipeDirection = transform.position - boxCollider.bounds.center;
    }

    private void OnTriggerStay(Collider other)
    {
        if (active)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(pipeDirection * Time.deltaTime * forceMultiplier * force);
            }
        }   
    }
}
