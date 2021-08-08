using UnityEngine;
using UnityEngine.UI;

public class LifeUIManager : MonoBehaviour
{
    public Image[] lives;
    public Sprite fullLife, emptyLife;

    void Start()
    {   
        if (PlayerPrefs.GetInt("Lives") == 2)
        {
            lives[0].sprite = fullLife;
            lives[1].sprite = fullLife;
            lives[2].sprite = fullLife;
        }

        if (PlayerPrefs.GetInt("Lives") == 2)
        {
            lives[0].sprite = fullLife;
            lives[1].sprite = fullLife;
            lives[2].sprite = emptyLife;
        }

        if (PlayerPrefs.GetInt("Lives") == 1)
        {
            lives[0].sprite = fullLife;
            lives[1].sprite = emptyLife;
            lives[2].sprite = emptyLife;
        }
    }
}
