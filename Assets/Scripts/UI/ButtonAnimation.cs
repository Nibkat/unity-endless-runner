using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PointerEnter()
    {
        animator.SetBool("PointerOver", true);
    }

    public void PointerExit()
    {
        animator.SetBool("PointerOver", false);
    }
}
