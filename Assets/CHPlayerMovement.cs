using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float rotationSpeed = 10f;

    public Transform cameraTransform;

    private Vector3 currentVelocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 movement =
            forward * vertical +
            right * horizontal;

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        Vector3 targetVelocity = movement * moveSpeed;

        currentVelocity = Vector3.MoveTowards(
            currentVelocity,
            targetVelocity,
            acceleration * Time.deltaTime
        );

        transform.position += currentVelocity * Time.deltaTime;

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}