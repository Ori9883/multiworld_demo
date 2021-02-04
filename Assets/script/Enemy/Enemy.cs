using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public virtual void death()
    {

    }
}
