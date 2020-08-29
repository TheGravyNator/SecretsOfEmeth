using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleboxController : TextboxController
{
    public bool typing;

    public bool WriteText(string text)
    {
        textField.text = "";
        gameObject.SetActive(true);
        typing = true;
        StartCoroutine(WriteTextbox(text));
        return true;
    }
    
    IEnumerator WriteTextbox(string text)
    {
        foreach (char letter in text)
        {
            textField.text += letter;
            yield return new WaitForSeconds(.05f);
        }
        typing = false;
    }
}
