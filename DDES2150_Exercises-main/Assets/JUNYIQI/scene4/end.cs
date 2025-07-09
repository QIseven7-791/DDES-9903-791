using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    public float fadeDuration = 1.5f;          // 黑幕渐显时间
    public float delayAfterFade = 2.5f;        // 黑幕完全盖住后的等待时间

    private Image img;
    private float alpha = 0f;
    private bool isFading = true;
    private bool hasLoaded = false;

    void Start()
    {
        img = GetComponent<Image>();
        alpha = 0f;
        img.color = new Color(0f, 0f, 0f, alpha); // 初始为透明黑
    }

    void Update()
    {
        if (isFading && alpha < 1f)
        {
            alpha += Time.deltaTime / fadeDuration;
            img.color = new Color(0f, 0f, 0f, Mathf.Clamp01(alpha));

            if (alpha >= 1f && !hasLoaded)
            {
                hasLoaded = true;
                Invoke(nameof(GameOver), delayAfterFade); // 渐显后延迟跳场景
            }
        }
    }

    void GameOver()
    {
        Application.Quit();
    }

}
