using System.Collections;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public GameObject logSlowPrefab, logFastPrefab;
    public GameController gameController;

    Vector2 logSize;

    void Start()
    {
        logSize = logSlowPrefab.GetComponent<SpriteRenderer>().size;

        gameController.onStart.AddListener(() => StartCoroutine("SpawnMiddle"));

        for (int i = 0; i < 8; i++)
        {
            SpawnLog(-1);
        }

        for (int i = 0; i < 8; i++)
        {
            SpawnLog(1);
        }
    }

    IEnumerator SpawnMiddle()
    {
        yield return new WaitForSeconds(1.3f);

        while (gameController.gameStarted)
        {
            if (Random.Range(0f, 1f) < 0.6f)
            {
                Instantiate(logFastPrefab, transform.position, Quaternion.identity, transform);
            }

            yield return new WaitForSeconds(2);
        }
    }

    void SpawnLog(float side)
    {
        Vector2 position = new Vector2(0.26f * side, Random.Range(1.1f, 15f));
        RaycastHit2D hit = Physics2D.BoxCast(position, logSize, 0, Vector2.zero);

        while (hit.collider)
        {
            position = new Vector2(0.26f * side, Random.Range(1.1f, 15f));
            hit = Physics2D.BoxCast(position, logSize, 0, Vector2.zero);
        }

        Instantiate(logSlowPrefab, position, Quaternion.identity, transform);
    }
}
