using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform target;
    public Transform cameraTransform;
    public RectTransform arrow;

    void Update()
    {
        Vector3 directionToTarget =
            target.position - cameraTransform.position;

        directionToTarget.y = 0f;

        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        directionToTarget.Normalize();

        float forwardAmount =
            Vector3.Dot(directionToTarget, cameraForward);

        float rightAmount =
            Vector3.Dot(directionToTarget, cameraRight);

        float angle =
            Mathf.Atan2(rightAmount, forwardAmount)
            * Mathf.Rad2Deg;

        arrow.localRotation =
            Quaternion.Euler(0f, 0f, -angle);
    }
}