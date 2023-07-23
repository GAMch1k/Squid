using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour {
    public bool triggered = false;
    public Animator animator;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player" || collision.tag == "Shadow") {
            triggered = true;
            animator.SetBool("isActive", true);
            //Debug.Log("LEVER OPENED");
        }
    }
    

    private void OnTriggerExit2D(Collider2D collision) {
        triggered = false;
        animator.SetBool("isActive", false);
    }
}
