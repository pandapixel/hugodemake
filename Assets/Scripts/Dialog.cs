using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text textDisplay;
    public string text;
    public UnityEvent onComplete;

    bool dialogFinish;

    void Start()
    {
        StartCoroutine("Type");
    }

    void Update()
    {
        if (Input.GetButton("Submit") && dialogFinish)
        {
            onComplete.Invoke();
            GetComponent<Animator>().SetTrigger("close");
        }
    }

    IEnumerator Type()
    {
        textDisplay.text = "";

        foreach (char letter in text.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        dialogFinish = true;
    }

    public void DestroyAfterAnim()
    {
        Destroy(gameObject);
    }
}
