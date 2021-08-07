using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameController gameController;
    public Transform player;

    float playerStartPos;
    int score;
    Text scoreText;

    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        gameController.onStart.AddListener(() => StartCoroutine("DistanceScore"));
        playerStartPos = player.position.y;
    }

    IEnumerator DistanceScore()
    {
        while (gameController.gameStarted)
        {
            score = (int) ((player.position.y - playerStartPos) * 10) * 10;
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = score.ToString();
    }
}
