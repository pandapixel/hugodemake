using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public bool gameStarted;
    public UnityEvent onStart;

    public void GameStart()
    {
        gameStarted = true;
        onStart.Invoke();
    }
}
