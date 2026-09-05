using UnityEngine;

public class BallHighlightController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject ballHighlight;

    public LayerMask obstructionLayers;

    void Update()
    {
        Vector3 directionToBall =
            transform.position - mainCamera.transform.position;

        float distanceToBall = directionToBall.magnitude;

        RaycastHit hit;

        if (Physics.Raycast(
            mainCamera.transform.position,
            directionToBall.normalized,
            out hit,
            distanceToBall,
            obstructionLayers
        ))
        {
            ballHighlight.SetActive(true);
        }
        else
        {
            ballHighlight.SetActive(false);
        }
    }
}