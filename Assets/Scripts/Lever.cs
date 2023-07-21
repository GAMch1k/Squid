using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour {
    public bool triggered = false;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player" || collision.tag == "Shadow") {
            triggered = true;
            Debug.Log("LEVER OPENED");
        }
    }
    

    private void OnTriggerExit2D(Collider2D collision) {
        triggered = false;
    }
}
