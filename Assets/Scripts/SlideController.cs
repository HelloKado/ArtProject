using UnityEngine;

public class SlideController : MonoBehaviour
{
    private Animator animator;
    private bool isSliding = false;
    private bool isFacingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isSliding = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            isSliding = false;
        }

        animator.SetBool("IsSliding", isSliding);
    }

    public void OnSlideAnimationEnd()
    {
        isSliding = false;
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
