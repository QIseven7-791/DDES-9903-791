using UnityEngine;

public class TeleportOnVisibleWithDelay : MonoBehaviour
{
    public Transform player;       // 玩家
    public Transform targetPoint;  // 传送目标位置
    public float delayTime = 1f;   // 延迟时间（秒）

    private bool hasTriggered = false;

    void Update()
    {
        // 如果物体已激活且还没触发过
        if (gameObject.activeInHierarchy && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine(TeleportAfterDelay());
        }
    }

    System.Collections.IEnumerator TeleportAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        player.position = targetPoint.position;
    }
}

