using UnityEngine;

public class DirectionalBoost : MonoBehaviour
{
    public float force = 10;
    public float abilityPushTime = 2f;
    public float cooldownTime = 2f;

    bool active = false;
    float cooldownTimer = 0;
    float abilityTimer = 0;

    void Update()
    {
        ManageAbility();
        if (Input.GetButtonUp("Fire1") && active)
        {
            OnRelease();
        }
        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            OnPush();
        }
    }

    void ManageAbility()
    {
        // After reaching max time ability will pop off
        if (active)
        {
            abilityTimer += Time.unscaledDeltaTime;
            if (abilityTimer >= abilityPushTime)
            {
                OnRelease();
                print("Max time reached");
            }
        }

        // Keeping track of cooldown time
        else if (!active && cooldownTimer > 0)
        {
            cooldownTimer -= Time.unscaledDeltaTime;
            if (cooldownTimer <= 0)
            {
                print("Ability active");
            }
        }
    }

    void OnPush()
    {
        active = true;

        TimeManager.SlowDown();
    }

    void OnRelease()
    {
        active = false;

        cooldownTimer = cooldownTime;
        abilityTimer = 0;
        active = false;
        TimeManager.BackToNormal();
        GetComponent<Rigidbody>().velocity = CameraRotation.cameraDirection * force;
    }

}
