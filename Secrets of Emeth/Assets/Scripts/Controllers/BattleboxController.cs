using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleboxController : TextboxController
{
    public bool typing;

    public bool WriteText(string text, bool key)
    {
        textField.text = "";
        gameObject.SetActive(true);
        typing = true;
        if (key) StartCoroutine(WriteTextboxKey(text));
        else StartCoroutine(WriteTextbox(text));
        return true;
    }

    IEnumerator WriteTextbox(string text)
    {
        foreach (char letter in text)
        {
            textField.text += letter;
            yield return new WaitForSeconds(.01f);
        }
        typing = false;
    }

    IEnumerator WriteTextboxKey(string text)
    {
        foreach (char letter in text)
        {
            textField.text += letter;
            yield return new WaitForSeconds(.01f);
        }
        yield return WaitForKeyPress();
        typing = false;
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
