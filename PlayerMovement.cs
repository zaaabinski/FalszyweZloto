using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    private float horizontal;
    private float jumpingPower = 12f;
    private bool facingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] AudioSource jumping;
    [SerializeField] ResScript RS;
    private void Start()
    {
        RS = GameObject.Find("Res").GetComponent<ResScript>();
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        if (Input.GetButtonDown("Jump") && IsGroundend())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumping.Play();
        }
        if (Input.GetButtonUp("Jump") && (rb.velocity.y > 0f))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * RS.speed, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(horizontal*RS.speed));
    }
    void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGroundend()
    {
        return Physics2D.OverlapCircle(groundCheck.position , 0.1f, groundLayer);
    }
}
