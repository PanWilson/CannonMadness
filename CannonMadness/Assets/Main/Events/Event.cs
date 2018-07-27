using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public abstract class Event : MonoBehaviour {
    
    public bool completed = false;
    public GameObject celebrateParticles;

    public abstract void CheckForCompletion();

    public virtual void OnCompletion() {
        completed = true;
    }
    public virtual void ShootParticles(Vector3 position)
    {
        GameObject p = Instantiate(celebrateParticles, transform);
        p.transform.position = position;
    }
    public virtual void PlayAudio(AudioClip clip = null)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (clip == null)
            audio.Play();
        else
            audio.PlayOneShot(clip);
            
    }
}
