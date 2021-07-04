using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController gameController;

    public void JumpFinish()
    {
        if (!gameController.gameStarted)
        {
            gameController.GameStart();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        transform.parent = other.transform;
    }
}
