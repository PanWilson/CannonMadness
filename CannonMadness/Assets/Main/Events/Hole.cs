using UnityEngine;

public class Hole : MonoBehaviour {

    bool active = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (active)
            {
                active = false;
                transform.parent.GetComponent<Event>().OnCompletion();
            }
        }
    }
}
