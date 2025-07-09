using UnityEngine;
using System.Collections;

public class daddycomehere : MonoBehaviour
{
    public AudioSource 音频源;          // 指向 Audio Source
    public float 循环间隔时间 = 5f;     // 每次播放之间的间隔（秒）
    public float 启动前延迟时间 = 1.5f; // 场景加载后首次播放前的延迟（秒）

    void Start()
    {
        StartCoroutine(开始播放());
    }

    IEnumerator 开始播放()
    {
        // 初始延迟
        yield return new WaitForSeconds(启动前延迟时间);

        while (true)
        {
            音频源.Play(); // 播放音频
            yield return new WaitForSeconds(音频源.clip.length); // 等待当前音频播放完
            yield return new WaitForSeconds(循环间隔时间);       // 等待间隔后再播放
        }
    }
}
