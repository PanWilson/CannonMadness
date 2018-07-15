using UnityEngine;

public class Hole : MonoBehaviour {

    public Transform particles;

    bool completed = false;
    bool active = true;

    private void Awake()
    {
        if (completed)
        {
            active = false;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (active)
            {
                Debug.Log("Hole Event successfuly completed");
                OnEventCompletion();
            }
        }
    }

    public void OnEventCompletion()
    {
        active = false;
        gameObject.SetActive(false);
        GetComponentInParent<AudioSource>().Play();
        Instantiate(particles, transform.position, particles.rotation, transform.parent);
        // Other things like sound or shit like that
    }
}
