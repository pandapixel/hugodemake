using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    public Text bagScoreText, lifeScoreText, finishedScoreText, totalScoreText;

    void Start()
    {
        StartCoroutine("Points");
    }

    IEnumerator Points()
    {
        int bagScore = PlayerPrefs.GetInt("BagScore") * 300;
        int lifeScore = PlayerPrefs.GetInt("Lives") * 500;
        int finishScore = PlayerPrefs.GetInt("Finished") == 1 ? 1000 : 0;
        int distanceScore = PlayerPrefs.GetInt("DistanceScore");
        int totalScore = bagScore + lifeScore + finishScore + distanceScore;

        for (int i = 0; i <= bagScore / 5; i++)
        {
            bagScoreText.text = $"{i * 5} pts";
            yield return 0;
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i <= lifeScore / 5; i++)
        {
            lifeScoreText.text = $"{i * 5} pts";
            yield return 0;
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i <= (distanceScore + finishScore) / 5; i++)
        {
            finishedScoreText.text = $"{i * 5} pts";
            yield return 0;
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i <= totalScore / 5; i++)
        {
            totalScoreText.text = $"{i * 5} pts";
            yield return 0;
        }

        PlayerPrefs.SetInt("BagScore", 0);
        PlayerPrefs.SetInt("Lives", 0);
        PlayerPrefs.SetInt("Finished", 0);
        PlayerPrefs.SetInt("DistanceScore", 0);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Credits");
    }
}
