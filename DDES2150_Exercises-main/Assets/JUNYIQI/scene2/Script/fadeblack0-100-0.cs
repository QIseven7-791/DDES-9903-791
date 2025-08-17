using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fadeblack0: MonoBehaviour
{
   
    public Image fadeImage;               // 黑幕 UI Image
    public float fadeDuration = 1f;       // 渐变时间
    public float blackScreenTime = 2f;    // 全黑保持时间
    public bool autoPlay = true;          // 激活时是否自动播放

    private bool hasPlayed = false;

    private void OnEnable()
    {
        if (autoPlay && !hasPlayed && fadeImage != null)
        {
            StartCoroutine(FadeInOut());
            hasPlayed = true;
        }
    }

    public void PlayFadeInOut()
    {
        if (!hasPlayed && fadeImage != null)
        {
            StartCoroutine(FadeInOut());
            hasPlayed = true;
        }
    }

    private IEnumerator FadeInOut()
    {
        // 渐显（黑幕出现）
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // 保持全黑
        yield return new WaitForSeconds(blackScreenTime);

        // 渐隐（黑幕消失）
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
