using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StiffCameraMode", menuName = "CameraModes/Stiff")]

public class StiffCameraMode : CameraMode {

    [SerializeField] Vector3 PositionOffset;
    [SerializeField] Vector3 RotationOffset;

    public override void onUpdate(GameObject n_camera)
    {
        if (!camera)
            camera = n_camera.GetComponent<CameraController>();

        camera.transform.position = camera.target.transform.position + PositionOffset;
        camera.transform.rotation = camera.target.transform.rotation * Quaternion.Euler(RotationOffset);
    }
}
