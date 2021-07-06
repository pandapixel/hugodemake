using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController gameController;

    bool isJumping;

    void Update()
    {
        if (Input.GetButton("Submit") && !gameController.gameStarted && !isJumping)
        {
            GetComponent<Animator>().SetTrigger("jumpRight");
            isJumping = true;
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
