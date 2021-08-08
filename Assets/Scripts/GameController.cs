using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject dialogPrefab;
    public Transform canvas;

    [HideInInspector]
    public bool gameStarted;
    [HideInInspector]
    public UnityEvent onStart;

    void Start()
    {
        if (PlayerPrefs.GetInt("Lives") == 3)
        {
            Dialog dialog = Instantiate(dialogPrefab, canvas).GetComponent<Dialog>();
            dialog.text = "SE O TRONCO NÃO VIRAR,\nNÓS VAMOS CHEGAR!";
            dialog.onComplete.AddListener(player.GetComponent<Player>().JumpStart);
        }
        else
        {
            player.GetComponent<Player>().JumpStart();
        }
    }

    public void GameStart()
    {
        gameStarted = true;
        onStart.Invoke();
    }

    public void Finish()
    {
        gameStarted = false;
        player.GetComponent<Animator>().SetTrigger("moveToFront");

        Dialog dialog = Instantiate(dialogPrefab, canvas).GetComponent<Dialog>();
        dialog.text = "MUITO BEM, VOCÊ CHEGOU!";
        dialog.onComplete.AddListener(() => SceneManager.LoadScene("Score"));
    }
}
