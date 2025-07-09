using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem1 : MonoBehaviour
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
        StartCoroutine(TypeText(testText,@"Do you remember Easter day?
You said if we bonk the bunny on the head with a stick 
lots and lots of candy would fall out!",speakspeed));

    }
}
