using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour
{
    public string sceneName;

    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
