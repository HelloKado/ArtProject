using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    private bool isMoving;
    private bool isFacingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        isMoving = Mathf.Abs(moveInput) > 0;

        if (isMoving)
        {
            // Move the character
            transform.Translate(new Vector2(moveInput * Time.deltaTime, 0));

            // Flip character sprite based on movement direction
            if ((isFacingRight && moveInput < 0) || (!isFacingRight && moveInput > 0))
            {
                FlipCharacter();
            }
        }

        // Set the animator parameters
        animator.SetBool("IsMoving", isMoving);
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
