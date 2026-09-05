using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Rigidbody ball;
    public Transform[] launchPoints;
    public float launchForce = 10f;

    public void LaunchBall()
    {
        int randomIndex = Random.Range(0, launchPoints.Length);

        Transform chosenLaunchPoint = launchPoints[randomIndex];

        ball.linearVelocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        ball.transform.position = chosenLaunchPoint.position;

        ball.AddForce(
            chosenLaunchPoint.forward * launchForce,
            ForceMode.Impulse
        );
    }
}