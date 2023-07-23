using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public bool triggered = false;
    public bool only_box = false;
    public Animator animator;

    private void OnTriggerStay2D(Collider2D collision) {
        if (only_box) {
            if (collision.tag == "Box") {
                triggered = true;
                animator.SetBool("isActive", true);
                //Debug.Log("BOX BUTTON OPENED");
            }
        } else {
            if (collision.tag == "Player" || collision.tag == "Box" || collision.tag == "Shadow") {
                triggered = true;
                animator.SetBool("isActive", true);
                //Debug.Log("BUTTON OPENED");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (only_box) { 
            if (collision.tag == "Box") {
                triggered = false;
                animator.SetBool("isActive", false);
            }
        } else {
            if (collision.tag != "Player" || collision.tag != "Shadow")
            {
                triggered = false;
                animator.SetBool("isActive", false);
            }
        }
    }
}
