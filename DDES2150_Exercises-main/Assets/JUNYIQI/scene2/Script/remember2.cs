using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class remember2 : MonoBehaviour
{
    public float speakspeed;
    public TMP_Text testText;
    IEnumerator TypeText(TMP_Text tMP_Text, string str, float interval)
    {
        int i = 0;
        while (i <= str.Length)
        {
            tMP_Text.text = str.Substring(0, i++);
            yield return new WaitForSeconds(interval);
        }
    }
    private void Start()
    {
        StartCoroutine(TypeText(testText, @"A portrait of my daughter
but with an indescribable sense of strangeness.
Do you want to see it?", speakspeed));

    }
}
