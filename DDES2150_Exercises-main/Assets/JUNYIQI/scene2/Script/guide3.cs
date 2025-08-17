using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem3 : MonoBehaviour
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
        StartCoroutine(TypeText(testText, @"The patient shows abnormal brain activity
especially in emotion and memory areas.
Hallucination-like patterns appeared multiple times during monitoring.
Responses to sound and visuals were slow
with signs of distorted perception.
Results suggest severe mental instability 
and risk of prolonged detachment from reality
", speakspeed));

    }
}
