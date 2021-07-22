using UnityEngine;

public class Log : MonoBehaviour
{
    public GameController gameController;
    public float speed = 0.5f;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (gameController.gameStarted)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
