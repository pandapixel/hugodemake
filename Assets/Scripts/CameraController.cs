using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
    }
}
