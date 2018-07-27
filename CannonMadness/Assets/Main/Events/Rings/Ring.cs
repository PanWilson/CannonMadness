using UnityEngine;

public class Ring : MonoBehaviour {

    public bool active;

    private Rings rings;

    private RingTrigger trigger;

    private void Awake()
    {
        active = true;

        rings = GetComponentInParent<Rings>();
        trigger = GetComponentInChildren<RingTrigger>();
    }

    public void Deactivate()
    {
        rings.ResetRings();
        GetComponent<AudioSource>().Play();
        active = false;
        trigger.gameObject.SetActive(false);
        rings.CheckForCompletion();
    }

    public void Activate()
    {
        active = true;
        trigger.gameObject.SetActive(true);
    }

    

}
