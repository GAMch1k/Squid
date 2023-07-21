using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public GameObject[] interactables;
    public bool opened = false;

    BoxCollider2D boxCollider;

    private void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        foreach (GameObject gobject in interactables) {
            try {
                if (!gobject.GetComponent<Lever>().triggered) {
                    CloseDoor();
                    break;
                }
            } catch {
                if (!gobject.GetComponent<Button>().triggered) {
                    CloseDoor();
                    break;
                }
            }

            OpenDoor();
        }   
    }

    public void OpenDoor() {
        opened = true;
        boxCollider.isTrigger = true;
    }

    public void CloseDoor() {
        opened = false;
        boxCollider.isTrigger = false;
    }
}
