using UnityEngine;

public class CHPlayerKick : MonoBehaviour
{
    public Rigidbody ball;
    public float kickPower = 10f;

    public float kickRange = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float distance = Vector3.Distance(transform.position, ball.transform.position);

            if(distance <= kickRange)
            {
                ball.AddForce(transform.forward * kickPower, ForceMode.Impulse);
            }
        }
    }
}
