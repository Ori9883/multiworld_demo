using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private Rigidbody2D rb;
    public Transform leftPoint;
    public Transform rightPoint;
    public float Speed;
    private float leftx, rightx;
    private bool faceleft = true;
    private bool stop = true;
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
        anim.SetBool("stop",stop);
    }

     void Movement()
    {
        if (faceleft == true)
        {
            if(stateinfo.IsName("slime-run"))
            {
                rb.velocity = new Vector2(-Speed, 0);
            }
            if (transform.position.x < leftx)
            {
                stop = true;
                rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
                faceleft = false;
            }
        }
        else if (faceleft == false)
        {
            if (stateinfo.IsName("slime-run"))
            {
                rb.velocity = new Vector2(Speed, 0);
            }
            if (transform.position.x > rightx)
            {
                stop = true;
                rb.velocity = new Vector2(0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                faceleft = true;
            }
        }
    }

    public void slimeStop()
    {
        stop = false;
    }

    public override void death()
    {
        base.death();
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
}
