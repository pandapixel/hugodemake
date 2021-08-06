using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public GameObject dialogFinish;
    public GameObject player;

    [HideInInspector]
    public bool gameStarted;
    [HideInInspector]
    public UnityEvent onStart;

    public void GameStart()
    {
        gameStarted = true;
        onStart.Invoke();
    }

    public void Finish()
    {
        gameStarted = false;
        dialogFinish.SetActive(true);
        player.GetComponent<Animator>().SetTrigger("moveToFront");
    }
}
