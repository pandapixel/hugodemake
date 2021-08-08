using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseManager : MonoBehaviour
{
    public GameObject dialogPrefab;
    public Transform canvas;

    void Start()
    {
        StartCoroutine("WaitForOpenDialog");
    }

    IEnumerator WaitForOpenDialog()
    {
        yield return new WaitForSeconds(1);
        Dialog dialog = Instantiate(dialogPrefab, canvas).GetComponent<Dialog>();

        if (PlayerPrefs.GetInt("Lives") == 2) dialog.text = "CAÍ NO PEIXE!";
        if (PlayerPrefs.GetInt("Lives") == 1) dialog.text = "SE LIGA! É A ÚLTIMA VIDA!";

        if (PlayerPrefs.GetInt("Lives") == 0)
        {
            dialog.text = "NÃO TEM CHORORÔ, ESTE JOGO\nACABOU!";
            dialog.onComplete.AddListener(() => SceneManager.LoadScene("Score"));
        }
        else
        {
            dialog.onComplete.AddListener(() => SceneManager.LoadScene("Game"));
        }
    }
}
