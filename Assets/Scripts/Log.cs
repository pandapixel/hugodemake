using UnityEngine;

public class Log : MonoBehaviour
{
    public GameController gameController;
    float speed = 0.5f;

    void Update()
    {
        if (gameController.gameStarted)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
