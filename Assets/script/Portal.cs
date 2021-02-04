using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int sceneNum;
    public bool inPortal;
    public GameObject enterDialog;

    private void Start()
    {
        inPortal = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(inPortal == true)
            {
                SceneManagement.instance.changeScene(sceneNum);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inPortal = true;
            enterDialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inPortal = false;
            enterDialog.SetActive(false);
        }
    }
}
