using UnityEngine;
// ReSharper disable InconsistentNaming

public class AudioPanelAnimEvents : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ExitPanel()
    {
        animator.SetInteger("ExitVersion", Random.Range(0, 3));
        animator.SetTrigger("ExitTrigger");
    }
}
