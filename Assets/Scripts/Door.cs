using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] interactables;
    public Animator anim;
    public bool opened = false;

    BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        foreach (GameObject gobject in interactables)
        {

            if (gobject.GetComponent<Lever>() != null)
            {
                if (!gobject.GetComponent<Lever>().triggered)
                {
                    CloseDoor();
                    break;
                }
            }

            if (gobject.GetComponent<Button>() != null)
            {
                if (!gobject.GetComponent<Button>().triggered)
                {
                    CloseDoor();
                    break;
                }
            }

            if (gobject.GetComponent<Wire>() != null)
            {
                if (!gobject.GetComponent<Wire>().triggered)
                {
                    CloseDoor();
                    break;
                }
            }

            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        boxCollider.isTrigger = true;
        anim.SetBool("Opened", true);
    }

    public void CloseDoor()
    {
        boxCollider.isTrigger = false;
        anim.SetBool("Opened", false);
    }
}