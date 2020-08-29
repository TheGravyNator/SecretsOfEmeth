using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxController : MonoBehaviour
{
    public Text textField;

    public void WriteText(string text)
    {
        GameManager.Instance.ChangeGameState(Gamestates.INTERACTING);
        textField.text = "";
        gameObject.SetActive(true);
        StartCoroutine(WriteTextbox(text));
    }

    IEnumerator WriteTextbox(string text)
    {
        foreach (char letter in text)
        {
            textField.text += letter;
            if(Input.GetButton("Jump")) yield return new WaitForSeconds(.01f);
            else yield return new WaitForSeconds(.05f);
        }
        yield return WaitForKeyPress();
        GameManager.Instance.ChangeGameState(GameManager.Instance.previousGameState);
        gameObject.SetActive(false);
    }

    IEnumerator WaitForKeyPress()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetButtonDown("Jump"))
            {
                done = true;
            }
            yield return null;
        }
    }
}
