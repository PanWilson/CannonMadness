using UnityEngine;

public class RingTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player passed the ring.");
            transform.parent.GetComponent<Ring>().Deactivate();
        }
    }

}
