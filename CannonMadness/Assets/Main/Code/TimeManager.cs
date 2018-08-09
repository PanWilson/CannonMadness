using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowValue = 0.05f;

    static private float realTimeFactor;
    static private float realFixedDeltaTime;
    static float slowDownFactor;

    private void Start()
    {
        slowDownFactor = slowValue;

        realTimeFactor = Time.timeScale;
        realFixedDeltaTime = Time.fixedDeltaTime;
    }

    static public void SlowDown(float value)
    {
        Time.timeScale = value;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    static public void SlowDown()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    static public void BackToNormal()
    {
        Time.timeScale = realTimeFactor;
        Time.fixedDeltaTime = realFixedDeltaTime;
    }
}