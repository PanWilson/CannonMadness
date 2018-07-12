using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    [SerializeField] bool debug;

    [SerializeField] float MaxFingerTilt;

    [SerializeField,Range(0,1)] float MarginTilt;

    [SerializeField] float speed;

    [SerializeField] float Power;

    [SerializeField] float tapGap;

    [SerializeField] GameObject projectile;

    [SerializeField] GameObject Arrow;

    [SerializeField,Range(0, 180)] float MaxLeanUp;

    [SerializeField,Range(0, -180)] float MaxLeanDown;

    int controllingTouchId;

    Vector2 initPosition;

    int tapCount;

    float tapTimer;

    [SerializeField] int trajectorySteps;

    [SerializeField] float debugRadius;

    float g;


    private void Awake()
    {
        tapCount = 0;
        tapTimer = 0;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
        GetTouch();
        TapDetection();
        if ((Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S))||(Input.touchCount > 0 && GetTouchByID(controllingTouchId).phase != TouchPhase.Ended)) {
            Rotate();
        }
	}

    void Rotate()
    {
        Touch controllingTouch = GetTouchByID(controllingTouchId);
        Vector2 FingerTilt = initPosition - controllingTouch.position;

        FingerTilt = Vector2.ClampMagnitude(FingerTilt,MaxFingerTilt);

        FingerTilt = FingerTilt.normalized * (FingerTilt.magnitude/MaxFingerTilt);

        if (Input.GetKey(KeyCode.A)) FingerTilt = new Vector2(-1, FingerTilt.y);
        if (Input.GetKey(KeyCode.D)) FingerTilt = new Vector2(1, FingerTilt.y);
        if (Input.GetKey(KeyCode.W)) FingerTilt = new Vector2(FingerTilt.x, 1);
        if (Input.GetKey(KeyCode.S)) FingerTilt = new Vector2(FingerTilt.x, -1);

        if (FingerTilt.magnitude > MarginTilt)
        {

            Vector3 rotationVector = new Vector3(0, FingerTilt.x * speed * Time.deltaTime, FingerTilt.y * speed * Time.deltaTime);

            if (ToNegativeAngles(transform.eulerAngles.z) + (FingerTilt.x * speed * Time.deltaTime) > MaxLeanUp)
            {
                rotationVector.z = MaxLeanUp - ToNegativeAngles(transform.eulerAngles.z);
            }

            if (ToNegativeAngles(transform.eulerAngles.z) + (FingerTilt.y * speed * Time.deltaTime) < MaxLeanDown)
            {
                rotationVector.z = MaxLeanDown - ToNegativeAngles(transform.eulerAngles.z);
            }
            transform.eulerAngles += rotationVector;
        }
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

    void TapDetection()
    {

        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (tapTimer < tapGap)
                {
                    tapCount++;
                    tapTimer = 0;
                }
            }
        }

        if(tapCount > 0) tapTimer += Time.deltaTime;

        if(tapTimer > tapGap)
        {
            print("Taps:"  + tapCount.ToString());
            tapTimer = 0;
            TapHandler(tapCount);
            tapCount = 0;
        }

    }

    void TapHandler(int count)
    {
        if (tapCount == 2)
        {
            Shoot();
            print("Shoot");
        }
    }

    void Shoot()
    {
        GameObject P = Instantiate(projectile,Arrow.transform.position,Quaternion.LookRotation(Arrow.transform.forward,Arrow.transform.up));
        P.GetComponent<ProjectileComponent>().LaunchProjectile(P.transform.forward, Power);
    }

    float ToNegativeAngles(float angle)
    {
        return (angle >= 180) ? angle-360:angle;
    }


    private void OnDrawGizmosSelected()
    {
        g = Mathf.Abs(Physics.gravity.y) * 100;
        float angle = Mathf.Deg2Rad * ToNegativeAngles(transform.eulerAngles.z + 45);
        float maxDistance = ((Power * Power) * Mathf.Sin(2 * angle)) / g;
        for (int i =0;i < trajectorySteps ; i++)
        {
            float alpha = (float)i / (float)trajectorySteps;

            float x = alpha * maxDistance;
            float y = (x * Mathf.Tan(angle)) - ((g * Mathf.Pow(x, 2)) / (2 * Mathf.Pow(Power, 2) * Mathf.Pow(Mathf.Cos(angle),2)));
            Gizmos.color = Color.red;
            Vector3 tra = new Vector3(x, y, 0);
            tra = Quaternion.Euler(0, transform.eulerAngles.y, 0) * tra;
            Gizmos.DrawSphere(Arrow.transform.position + tra,debugRadius);
        }


    }
}
