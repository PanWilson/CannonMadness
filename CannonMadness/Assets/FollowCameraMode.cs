using UnityEngine;

[CreateAssetMenu(fileName = "FollowCameraMode", menuName = "CameraModes/Follow")]

public class FollowCameraMode : CameraMode
{
    [SerializeField] Vector3 PositionOffset;
    [SerializeField] Vector3 RotationOffset;

    [SerializeField] float PositionSpeed;
    [SerializeField] float RotationSpeed;

    [SerializeField] bool withSnap;

    public override void onStart(GameObject n_camera)
    {
        if (withSnap)
        {
            n_camera.transform.position = n_camera.GetComponent<CameraController>().target.transform.position;
            n_camera.transform.rotation = n_camera.GetComponent<CameraController>().target.transform.rotation;
        }
    }

    public override void onUpdate(GameObject n_camera)
    {
        if (!camera)
            camera = n_camera.GetComponent<CameraController>();

        Vector3 hPosition = camera.target.transform.position + PositionOffset;
        camera.transform.position = Vector3.Lerp(camera.transform.position, hPosition, PositionSpeed);

        Quaternion hRotation = camera.target.transform.rotation * Quaternion.Euler(RotationOffset);
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation,hRotation,RotationSpeed);
    }
}
