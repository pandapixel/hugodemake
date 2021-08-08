using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.SetInt("Lives", 3);
        SceneManager.LoadScene("Game");
    }
}
