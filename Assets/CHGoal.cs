using UnityEngine;

public class CHGoal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("GOAL!");
        }
    }
}
