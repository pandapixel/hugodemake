using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController gameController;

    Animator anim;
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
        if (Input.GetButton("Submit") && !gameController.gameStarted && !isJumping)
        {
            anim.SetTrigger("jumpRight");
            isJumping = true;
            position = 1;
        }

        if (Input.GetAxis("Horizontal") > 0 && !isJumping && position < 2)
        {
            anim.SetTrigger("jumpRight");
            isJumping = true;
            position++;
        }
        if (Input.GetAxis("Horizontal") < 0 && !isJumping && position > 0)
        {
            anim.SetTrigger("jumpLeft");
            isJumping = true;
            position--;
        }
    }

    public void JumpFinish()
    {
        isJumping = false;
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
