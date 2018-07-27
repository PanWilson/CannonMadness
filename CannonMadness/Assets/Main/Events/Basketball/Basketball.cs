using UnityEngine;

public class Basketball : Event {

    public override void OnCompletion()
    {
        base.OnCompletion();

        StopAllCoroutines();
        Debug.Log("You have scored a basket.");

        ShootParticles(transform.position);
        PlayAudio();
    }

    public override void CheckForCompletion()
    {
        throw new System.NotImplementedException();
    }
}
