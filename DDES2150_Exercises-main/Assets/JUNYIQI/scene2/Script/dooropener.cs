using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public float 目标角度 = 90f;         // 开门角度（Y轴）
    public float 旋转速度 = 90f;        // 每秒旋转角度
    public bool 自动开启 = false;       // 是否在 Start 时就开门

    private bool 正在开门 = false;
    private Quaternion 初始角度;
    private Quaternion 目标旋转;

    void Start()
    {
        初始角度 = transform.rotation;
        目标旋转 = 初始角度 * Quaternion.Euler(0, 目标角度, 0);

        if (自动开启)
            正在开门 = true;
    }

    void Update()
    {
        if (正在开门)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, 目标旋转, 旋转速度 * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, 目标旋转) < 0.1f)
                正在开门 = false;
        }
    }

    public void 打开门()
    {
        正在开门 = true;
    }
}
