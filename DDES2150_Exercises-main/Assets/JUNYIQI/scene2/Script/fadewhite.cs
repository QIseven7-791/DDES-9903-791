using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fadewhite : MonoBehaviour
{
    public Image 遮罩图像;
    public float 渐显时长 = 1.5f; // 渐显用时（秒）

    void Start()
    {
        StartCoroutine(开始渐显());
    }

    IEnumerator 开始渐显()
    {
        Color 颜色 = 遮罩图像.color;
        float 当前时间 = 0f;

        while (当前时间 < 渐显时长)
        {
            当前时间 += Time.deltaTime;
            float 透明度 = Mathf.Lerp(1f, 0f, 当前时间 / 渐显时长);
            遮罩图像.color = new Color(颜色.r, 颜色.g, 颜色.b, 透明度);
            yield return null;
        }

        // 最后确保完全透明
        遮罩图像.color = new Color(颜色.r, 颜色.g, 颜色.b, 0f);
        // 可选：禁用图像组件，避免挡住后续 UI
        遮罩图像.gameObject.SetActive(false);
    }
}

