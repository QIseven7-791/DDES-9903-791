using UnityEngine;

public class DollDeathTrigger : MonoBehaviour
{
    public string triggerTag = "Default";
    private Animator animator;
    private bool hasDied = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasDied && other.CompareTag(triggerTag))
        {
            hasDied = true;
            animator.SetTrigger("die");
        }
    }
}
