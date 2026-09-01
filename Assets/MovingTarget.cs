using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public Transform[] spawnPoints;

    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        MoveToRandomSpawn();
    }

    public void MoveToRandomSpawn()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        transform.position = spawnPoints[randomIndex].position;

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