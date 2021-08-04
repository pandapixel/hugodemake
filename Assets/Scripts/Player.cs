using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController gameController;
    public GameObject perdeuTudo;

    Animator anim;
    GameObject steppingLog;
    bool isJumping;
    int position;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && !isJumping && position < 2)
        {
            anim.SetTrigger("jumpRight");
            isJumping = true;
            position++;
        }
        if (Input.GetAxisRaw("Horizontal") < 0 && !isJumping && position > 0)
        {
            anim.SetTrigger("jumpLeft");
            isJumping = true;
            position--;
        }
    }

    public void StartGame()
    {
        anim.SetTrigger("jumpRight");
        isJumping = true;
        position = 1;
    }

    public void JumpFinish()
    {
        isJumping = false;

        if (!gameController.gameStarted)
        {
            gameController.GameStart();
        }

        if (!steppingLog)
        {
            perdeuTudo.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        transform.parent = col.transform;
        steppingLog = col.gameObject;
        steppingLog.GetComponent<Log>().isPlayerAbove = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        steppingLog.GetComponent<Log>().isPlayerAbove = false;
        steppingLog = null;
    }
}
