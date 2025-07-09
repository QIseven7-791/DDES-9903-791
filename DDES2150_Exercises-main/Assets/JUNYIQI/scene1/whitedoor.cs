using UnityEngine;
using UnityEngine.SceneManagement;

public class 碰撞检测切换场景 : MonoBehaviour
{
    public Collider 玩家碰撞体;      // 拖入玩家的 Collider
    public Collider 触发区域碰撞体;  // 拖入触发区域（比如 Cube）的 Collider
    public string 下一个场景名称 = "MainScene";

    private bool 已触发 = false;

    void Update()
    {
        if (!已触发 && 玩家碰撞体.bounds.Intersects(触发区域碰撞体.bounds))
        {
            已触发 = true;
            SceneManager.LoadScene(下一个场景名称);
        }
    }
}
