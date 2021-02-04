using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFire : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            anim.Play("extinct");
        }
    }

    public void Death()
    {
        GameManager.instance.setWorldFire();
        Destroy(gameObject);
    }
}
