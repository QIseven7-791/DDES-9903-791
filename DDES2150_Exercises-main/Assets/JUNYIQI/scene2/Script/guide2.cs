using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem2 : MonoBehaviour
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
        StartCoroutine(TypeText(testText, @"Patient Name: Alex
Record ID: #A-0472-C
Date of Observation: April 8
Attending Physician: Dr. QI

The patient exhibits persistent cognitive 
distortion and remains immersed 
in a self-constructed internal framework.
Behavior demonstrates repetition and goal orientation
with clear influence from specific emotional projections.
Speech remains coherent; however
affect is incongruent with external stimuli.

", speakspeed));

    }
}
