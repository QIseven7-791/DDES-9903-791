using UnityEngine;

[ExecuteAlways]
public class 溶解中心 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    public Material material;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target && material)
        {
            material.SetVector("_Center", target.position);

        }
    }
}
