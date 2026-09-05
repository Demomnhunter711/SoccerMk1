using UnityEngine;

public class CHGoal : MonoBehaviour
{

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("GOAL!");

            gameManager.AddGoal();
            
        }
    }
}
