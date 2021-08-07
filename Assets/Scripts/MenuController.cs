using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.SetInt("Lives", 2);
        SceneManager.LoadScene("Game");
    }
}
