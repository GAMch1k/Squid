using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public bool triggered = false;
    public bool only_box = false;

    private void OnTriggerStay2D(Collider2D collision) {
        if (only_box) {
            if (collision.tag == "Box") {
                triggered = true;
                Debug.Log("BOX BUTTON OPENED");
            }
        } else {
            if (collision.tag == "Player" || collision.tag == "Box" || collision.tag == "Shadow") {
                triggered = true;
                Debug.Log("BUTTON OPENED");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        triggered = false;
    }
}
