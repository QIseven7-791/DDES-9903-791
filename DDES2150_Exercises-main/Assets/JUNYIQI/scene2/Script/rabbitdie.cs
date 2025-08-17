using UnityEngine;

public class 兔子被打掉 : MonoBehaviour
{
    public Collider 木棍碰撞体;       // 拖入木棍的碰撞体
    public GameObject[] 出现物品组;   // 拖入这只兔子打掉后要出现的东西
    private Collider 自身碰撞体;
    public GameObject bgm2;
    private bool 已触发 = false;

    void Start()
    {
        自身碰撞体 = GetComponent<Collider>();
    }

    void Update()
    {
        if (!已触发 && 木棍碰撞体.bounds.Intersects(自身碰撞体.bounds))
        {
            已触发 = true;

            // 显示对应物品
            foreach (GameObject 物品 in 出现物品组)
            {
                物品.SetActive(true);
            }

            // 销毁兔子自身
            Destroy(gameObject);
            Destroy(bgm2);
        }
    }
}
