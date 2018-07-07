using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    [SerializeField] bool debug;

    [SerializeField] float MaxFingerTilt;

    [SerializeField] float speed;

    [SerializeField] GameObject projectile;

    int controllingTouchId;

    Vector2 initPosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        GetTouch();
        if (Input.touchCount > 0 && GetTouchByID(controllingTouchId).phase != TouchPhase.Ended) {
            Rotate();
        }
	}

    void Rotate()
    {
        Touch controllingTouch = GetTouchByID(controllingTouchId);
        Vector2 FingerTilt = initPosition - controllingTouch.position;

        FingerTilt = Vector2.ClampMagnitude(FingerTilt, MaxFingerTilt);

        FingerTilt.Normalize();

        transform.localEulerAngles += new Vector3(0, FingerTilt.x * speed * Time.deltaTime, FingerTilt.y * speed * Time.deltaTime);
    }

    void GetTouch()
    {
        if(Input.touchCount > 0)
        {
            if (GetTouchByID(controllingTouchId).phase != TouchPhase.Ended)
            {

                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if(debug)print("RotatingTouch");
                    controllingTouchId = Input.GetTouch(0).fingerId;
                    initPosition = Input.GetTouch(0).position;
                }
            }
        }

    }

    Touch GetTouchByID(int id)
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.fingerId == id) return touch;
        }
        return new Touch();
    }

 

}
