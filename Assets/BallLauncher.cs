using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Rigidbody ball;
    public Transform launchPoint;
    public float launchForce = 10f;

    public void LaunchBall()
    {
        ball.linearVelocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        ball.transform.position = launchPoint.position;

        ball.AddForce(
            launchPoint.forward * launchForce,
            ForceMode.Impulse
        );
    }
}