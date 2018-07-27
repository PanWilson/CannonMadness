using System.Collections;
using UnityEngine;

public class Rings : Event {

    private Ring[] rings;

    private bool timerActive;
    public float resetDelay;

    private void Awake()
    {
        timerActive = false;
        rings = GetComponentsInChildren<Ring>();
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

    public override void CheckForCompletion()
    {
        foreach (Ring ring in rings)
        {
            if (ring.active)
            {
                return;
            }
        }
        OnCompletion();
    }

    public override void OnCompletion()
    {
        base.OnCompletion();

        StopAllCoroutines();
        Debug.Log("You have passed all the rings.");

        ShootParticles(transform.position);
        PlayAudio();
    }
}
