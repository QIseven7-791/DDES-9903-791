using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class 雷声剧情控制器_加强版 : MonoBehaviour
{
    [Header("玩家与传送点")]
    public GameObject 玩家;
    public Transform 房间传送点;
    public Transform 回到传送点;

    [Header("黑幕 UI")]
    public Image 黑幕;
    public float 渐变时间 = 1f;

    [Header("BGM 控制")]
    public GameObject 第二段BGM物体;

    [Header("控制物体")]
    public GameObject[] 第一次出现物体;
    public GameObject[] 第二次出现物体;
    public GameObject[] 第一次隐藏物体;
    public GameObject[] 第二次隐藏物体;

    [Header("时机设置")]
    public float 初始等待 = 1.5f;
    public float 闪电展示时长 = 2f;
    public float 黑幕保持时长 = 2f;
    public float 最终传送前等待 = 1f;

    private bool 已触发 = false;

    void Update()
    {
        if (!已触发 && gameObject.activeInHierarchy)
        {
            已触发 = true;
            StartCoroutine(完整流程());
        }
    }

    IEnumerator 完整流程()
    {
        黑幕.gameObject.SetActive(true);
        SetAlpha(0);
        yield return 黑幕渐显();

        yield return new WaitForSeconds(初始等待);

        玩家.transform.position = 房间传送点.position;

        // 第一轮
        yield return 闪电流程(第一次出现物体, 第一次隐藏物体);
        yield return new WaitForSeconds(黑幕保持时长);

        // 第二轮
        yield return 闪电流程(第二次出现物体, 第二次隐藏物体);
        yield return new WaitForSeconds(黑幕保持时长 + 最终传送前等待);

        // 回传送点，隐藏所有物体
        玩家.transform.position = 回到传送点.position;

        if (第二段BGM物体 != null)
            第二段BGM物体.SetActive(true);

        隐藏物体组(第一次出现物体);
        隐藏物体组(第二次出现物体);
        隐藏物体组(第一次隐藏物体);
        隐藏物体组(第二次隐藏物体);

        yield return 黑幕渐隐();
    }

    IEnumerator 闪电流程(GameObject[] 出现组, GameObject[] 隐藏组)
    {
        yield return 黑幕渐隐();

        foreach (GameObject obj in 出现组)
            if (obj != null) obj.SetActive(true);

        foreach (GameObject obj in 隐藏组)
            if (obj != null) obj.SetActive(false);

        yield return new WaitForSeconds(闪电展示时长);
        yield return 黑幕渐显();
    }

    IEnumerator 黑幕渐显()
    {
        float t = 0f;
        while (t < 渐变时间)
        {
            t += Time.deltaTime;
            SetAlpha(Mathf.Lerp(0f, 1f, t / 渐变时间));
            yield return null;
        }
        SetAlpha(1f);
    }

    IEnumerator 黑幕渐隐()
    {
        float t = 0f;
        while (t < 渐变时间)
        {
            t += Time.deltaTime;
            SetAlpha(Mathf.Lerp(1f, 0f, t / 渐变时间));
            yield return null;
        }
        SetAlpha(0f);
    }

    void SetAlpha(float alpha)
    {
        Color c = 黑幕.color;
        c.a = alpha;
        黑幕.color = c;
    }

    void 隐藏物体组(GameObject[] 物体组)
    {
        foreach (GameObject obj in 物体组)
            if (obj != null) obj.SetActive(false);
    }
}



