using UnityEngine;

public class Ring : MonoBehaviour {

    public bool active;

    private RingsEvent ringsEvent;

    private RingTrigger trigger;

    private void Awake()
    {
        active = true;

        ringsEvent = GetComponentInParent<RingsEvent>();
        trigger = GetComponentInChildren<RingTrigger>();
    }

    public void Deactivate()
    {
        ringsEvent.ResetRings();
        GetComponent<AudioSource>().Play();
        active = false;
        trigger.gameObject.SetActive(false);
        ringsEvent.CheckForCompletion();
    }

    public void Activate()
    {
        active = true;
        trigger.gameObject.SetActive(true);
    }

    

}
