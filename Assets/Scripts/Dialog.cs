using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text textDisplay;
    public UnityEvent onComplete;

    string sentence;
    bool dialogFinish;

    void Start()
    {
        sentence = textDisplay.text;
        StartCoroutine("Type");
    }

    void Update()
    {
        if (Input.GetButton("Submit") && dialogFinish)
        {
            onComplete.Invoke();
            gameObject.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        textDisplay.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        dialogFinish = true;
    }
}
