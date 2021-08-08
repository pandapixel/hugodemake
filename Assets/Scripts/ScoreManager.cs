using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameController gameController;
    public Transform player;

    float playerStartPos;
    int score;
    int bagScore;
    Text scoreText;

    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        gameController.onStart.AddListener(() => StartCoroutine("DistanceScore"));
        playerStartPos = player.position.y;
        PlayerPrefs.SetInt("Score", 0);
    }

    IEnumerator DistanceScore()
    {
        while (gameController.gameStarted)
        {
            score = (int) ((player.position.y - playerStartPos) * 10) * 10;
            scoreText.text = (bagScore + score).ToString();
            PlayerPrefs.SetInt("DistanceScore", score);
            yield return new WaitForSeconds(1);
        }
    }

    public void AddScore(int scoreAdd)
    {
        bagScore += scoreAdd;
        scoreText.text = (score + bagScore).ToString();
    }
}
