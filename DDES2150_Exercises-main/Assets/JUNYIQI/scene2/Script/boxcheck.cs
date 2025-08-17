using UnityEngine;

public class 碰撞检测显示隐藏 : MonoBehaviour
{
    public Collider 玩家碰撞体;         // 拖入玩家的 Collider
    public Collider 触发区域碰撞体;     // 拖入触发区域 Collider

    public GameObject[] 显示物体组;     // 要显示的物体
    public GameObject[] 隐藏物体组;     // 要隐藏的物体

    private bool 已触发 = false;

    void Update()
    {
        if (!已触发 && 玩家碰撞体.bounds.Intersects(触发区域碰撞体.bounds))
        {
            已触发 = true;

            // 显示一组物体
            foreach (GameObject obj in 显示物体组)
            {
                if (obj != null)
                    obj.SetActive(true);
            }

            // 隐藏另一组物体
            foreach (GameObject obj in 隐藏物体组)
            {
                if (obj != null)
                    obj.SetActive(false);
            }
        }
    }
}
