using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem4 : MonoBehaviour
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
        StartCoroutine(TypeText(testText, @"On Easter morning
local authorities confirmed
the death of a young girl found in her home.
Preliminary investigation
indicates the cause of death
was blunt force trauma to the head.
 Further details have not been released
and the case remains under active investigation.
", speakspeed));

    }
}
