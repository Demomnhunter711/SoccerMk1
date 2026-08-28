using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offset =
            Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        transform.position =
            startPosition + Vector3.right * offset;
    }
}
