using System.Collections;
using UnityEngine;

public class RingsEvent : MonoBehaviour {

    private Ring[] rings;

    private bool timerActive;
    public float resetDelay;

    private bool eventCompleted = false;

    private void Awake()
    {
        timerActive = false;
        InitializeRings();
    }

    void InitializeRings()
    {
        rings = GetComponentsInChildren<Ring>();
        if (eventCompleted)
        {
            foreach (Ring ring in rings)
            {
                ring.Deactivate();
            }
        }
    }

    public void ResetRings()
    {
        if (!timerActive)
        {
            StartCoroutine(RingsReseter(resetDelay));
        }
    }

    IEnumerator RingsReseter(float seconds)
    {
        timerActive = true;
        yield return new WaitForSeconds(seconds);
        foreach (Ring ring in rings)
        {
            ring.Activate();
        }
        timerActive = false;
    }

    public void CheckForCompletion()
    {
        foreach (Ring ring in rings)
        {
            if (ring.active)
            {
                return;
            }
        }
        Success();
    }

    public void Success()
    {
        StopAllCoroutines();
        eventCompleted = true;
        Debug.Log("You have passed all the rings.");
    }

}
