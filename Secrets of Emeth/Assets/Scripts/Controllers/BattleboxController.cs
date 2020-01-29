using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleboxController : TextboxController
{
    public void WriteText(string text)
    {
        textField.text = "";
        gameObject.SetActive(true);
        StartCoroutine(WriteTextbox(text));
    }

    IEnumerator WriteTextbox(string text)
    {
        foreach (char letter in text)
        {
            textField.text += letter;
            yield return new WaitForSeconds(.05f);
        }
    }
}
