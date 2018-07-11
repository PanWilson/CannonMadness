using UnityEngine;

public class RingTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<Ring>().Deactivate();
        }
    }

}
