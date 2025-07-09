using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem6 : MonoBehaviour
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
        StartCoroutine(TypeText(testText, @"We are committed to providing every patient with a professional
safe, and comforting rehabilitation environment.
With advanced medical systems
attentive care, and personalized treatment plans
we are helping countless minds find peace again.

Kandy Mental Rehabilitation Center ¡ª Caring for every heart with compassion.

", speakspeed));

    }
}
