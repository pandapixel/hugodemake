using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameController gameController;

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

    public void JumpStart()
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
            LoseLife();
        }
    }

    void LoseLife()
    {
        int lives = PlayerPrefs.GetInt("Lives") - 1;

        if (lives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt("Lives", lives);
        }
        else
        {
            SceneManager.LoadScene("Score");
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
