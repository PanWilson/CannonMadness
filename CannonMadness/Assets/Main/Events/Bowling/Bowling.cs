using UnityEngine;

public class Bowling : Event {

    BowlingPin[] pins;

    private void Start()
    {
        pins = transform.GetComponentsInChildren<BowlingPin>();
    }

    public override void CheckForCompletion()
    {
        foreach(BowlingPin pin in pins)
        {
            if (pin.standing == true)
                return;
        }
        OnCompletion();
    }

    public override void OnCompletion()
    {
        base.OnCompletion();

        Debug.Log("Bowling even completed.");

        ShootParticles(transform.position);
        PlayAudio();
    }

}
