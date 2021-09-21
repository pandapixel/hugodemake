using UnityEngine;

public class BagManager : MonoBehaviour
{
    public GameObject bagPrefab;

    Vector2 bagSpriteSize;

    void Start()
    {
        bagSpriteSize = bagPrefab.GetComponent<SpriteRenderer>().size + Vector2.one;

        for (int i = 0; i < 10; i++)
        {
            SpawnBag();
        }
    }

    void SpawnBag()
    {
        int side = Random.Range(0, 2) == 0 ? -1 : 1;
        float x = bagPrefab.transform.position.x * side;
        float y = Random.Range(1, 61) * 0.32f - 0.065f;

        Vector2 position = new Vector2(x, y);
        RaycastHit2D hit = Physics2D.BoxCast(position, bagSpriteSize, 0, Vector2.zero);

        while (hit.collider)
        {
            side = Random.Range(0, 2) == 0 ? -1 : 1;
            x = bagPrefab.transform.position.x * side;
            y = Random.Range(1, 61) * 0.32f - 0.065f;

            position = new Vector2(x, y);
            hit = Physics2D.BoxCast(position, bagSpriteSize, 0, Vector2.zero);
        }

        GameObject bag = Instantiate(bagPrefab, position, Quaternion.identity, transform);
        bag.transform.localScale = new Vector3(side, 1, 1);
    }
}
