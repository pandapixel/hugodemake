using UnityEngine;

public class Log : MonoBehaviour
{
    public GameController gameController;
    public float speed = 0.5f;

    [HideInInspector]
    public bool isPlayerAbove;

    Animator anim;
    bool keepFloating;

    void Start()
    {
        anim = GetComponent<Animator>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        keepFloating = true;
    }

    void Update()
    {
        if (gameController.gameStarted && keepFloating)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish")
        {
            keepFloating = false;

            if (isPlayerAbove)
            {
                gameController.Finish();
            }
            else
            {
                anim.SetTrigger("sink");
            }
        }
    }

    public void DestroyAfterAnim()
    {
        Destroy(gameObject);
    }
}
