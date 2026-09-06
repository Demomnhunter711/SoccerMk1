using UnityEngine;

public class BallDirectionIndicator : MonoBehaviour
{
    public Transform ball;

    void Update()
    {
        Vector3 directionToBall =
            ball.position - transform.position;

        directionToBall.y = 0f;

        if (directionToBall != Vector3.zero)
        {
            transform.rotation =
                Quaternion.LookRotation(directionToBall);
        }
    }
}