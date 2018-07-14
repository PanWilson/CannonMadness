using UnityEngine;

public class Bin : MonoBehaviour {

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
                Debug.Log("Bin Event successfuly completed");
                OnEventCompletion();
            }
        }
    }

    public void OnEventCompletion()
    {
        active = false;
        gameObject.SetActive(false);

        // Other things like sound or shit like that
    }
}
