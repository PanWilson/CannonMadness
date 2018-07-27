using UnityEngine;

public class TrashBin : Event {

    public override void OnCompletion()
    {
        base.OnCompletion();

        StopAllCoroutines();
        Debug.Log("You have passed all the rings.");

        ShootParticles(transform.position);
        PlayAudio();
    }

    public override void CheckForCompletion()
    {
        throw new System.NotImplementedException();
    }
}
