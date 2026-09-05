using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;


public class GameManager : MonoBehaviour
{
    public int score = 0;
    public BallLauncher ballLauncher;
    public Rigidbody ball;
    public Transform ballStartPosition;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text gameOverText;
    public float timeRemaining = 120f;
    bool gameOver = false;
    

    public void AddGoal()
    {
        if(gameOver == true)
        {
            return;
        }
        score++;

        scoreText.text = "Score: " + score;

        ballLauncher.LaunchBall();
       // ResetBall();
    }

    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            UpdateTimerDisplay();

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;

                EndGame();
            }
        }
    }

    void EndGame()
    {
        gameOver = true;

        gameOverText.gameObject.SetActive(true);

        Debug.Log("GAME OVER");
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = minutes + ":" + seconds.ToString("00");
    }

    void ResetBall()
    {
        ball.linearVelocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        ball.transform.position = ballStartPosition.position;
    }
}
