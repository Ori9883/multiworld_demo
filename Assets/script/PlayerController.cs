using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float scale_x;
    public float scale_y;

    public float speed;
    public float jumpForce;

    [Header("States Check")]
    public bool isGround;
    public bool canJump;
    public bool isJump;

    [Header("Ground Check")]
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Animation State")]
    private Animator anim;
    AnimatorStateInfo stateinfo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        stateinfo = anim.GetCurrentAnimatorStateInfo(0);
    }

    public void FixedUpdate()
    {
        PhysicsCheck();
        Movement();
        Jump();
    }

    void CheckInput()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            canJump = true;
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(horizontalInput * scale_x, 1 * scale_y, 1);
        }
    }
    void Jump()
    {
        if (canJump)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 2;
            canJump = false;
        }
    }

    void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGround)
        {
            rb.gravityScale = 1;
            isJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            if (stateinfo.IsName("fall"))
            {
                collision.gameObject.GetComponent<Enemy>().death();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.8f);
                anim.SetBool("jump", true);
            }
        }
    }
}
