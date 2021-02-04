using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPig : Enemy
{
    private Rigidbody2D rb;
    public Transform leftPoint;
    public Transform rightPoint;
    public float Speed;
    private float leftx, rightx;
    private bool faceleft = true;
    AnimatorStateInfo stateinfo;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        leftx = leftPoint.position.x;
        rightx = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        Movement();
    }

    void Movement()
    {
        if (faceleft == true)
        {
            rb.velocity = new Vector2(-Speed, 0);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faceleft = false;
            }
        }
        else if (faceleft == false)
        {
            rb.velocity = new Vector2(Speed, 0);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceleft = true;
            }
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

    public void destoryPig()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
}
