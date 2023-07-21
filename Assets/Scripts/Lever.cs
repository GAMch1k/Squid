using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
    public bool triggered = false;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player" || collision.tag == "Shadow") {
            triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        triggered = false;
    }
}
