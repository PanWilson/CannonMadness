using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] CameraMode currentMode;

    [SerializeField] public GameObject target;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        if (currentMode != null)
            currentMode.onStart(gameObject);
	}
	
	// Update is called once per frame
	void LateUpdate() {
        if (currentMode != null)
           currentMode.onUpdate(gameObject);
    }

    private void OnDestroy()
    {
        if (currentMode != null)
            currentMode.onEnd(gameObject);
    }

    public void SetMode(CameraMode mode)
    {
        currentMode = mode;
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }

    
}
