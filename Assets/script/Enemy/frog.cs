using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : Enemy
{
    private Rigidbody2D rb;
    //private Animator Anim;
    private Collider2D coll;
    public Transform leftPoint;
    public Transform rightPoint;
    public LayerMask Ground;
    public float Speed, jumpForce;
    private float leftx, rightx;
    private bool faceleft = true;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        //transform.DetachChildren(); 分离子级
        leftx = leftPoint.position.x;
        rightx = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnim();
    }

    void Movement()
    {
        if (faceleft == true)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(-Speed, jumpForce);
            }
            if (transform.position.x < leftx)
            {
                rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
                faceleft = false;
            }
        }
        else if (faceleft == false)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(Speed, jumpForce);
            }
            if (transform.position.x > rightx)
            {
                rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                faceleft = true;
            }
        }
    }

    void SwitchAnim()
    {
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0.1)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        if (coll.IsTouchingLayers(Ground) && anim.GetBool("falling"))
        {
            anim.SetBool("falling", false);
        }
    }

    public override void death()
    {
        base.death();
        playerFall();
    }

    public void playerFall()
    {
        anim.SetTrigger("death");
    }

    public void destoryFrog()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
}
