using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isJumping = false;
    [SerializeField] private float jumpForce = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }

        animator.SetBool("IsJumping", isJumping);
    }

    private void Jump()
    {
        isJumping = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
