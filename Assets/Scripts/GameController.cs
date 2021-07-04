using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public bool gameStarted;

    public void GameStart()
    {
        gameStarted = true;
    }
}
