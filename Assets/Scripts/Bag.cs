using UnityEngine;

public class Bag : MonoBehaviour
{
    public Sprite emptySprite;

    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerPrefs.SetInt("BagScore", PlayerPrefs.GetInt("BagScore") + 1);
            scoreManager.AddScore(300);
            GetComponent<SpriteRenderer>().sprite = emptySprite;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
