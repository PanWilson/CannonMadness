using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour {

    [SerializeField] ForceMode ForceMode = ForceMode.Impulse;

    Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LaunchProjectile(Vector3 direction, float force)
    {
        if (rb) {
            rb.AddForce(direction * force,ForceMode);
        }
    }
}
