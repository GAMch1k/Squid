using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public GameObject[] interactables;
    public bool opened = false;
    private bool opened_previous = false;

    private Animator _door_stone_animator;

    BoxCollider2D boxCollider;

    private void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        _door_stone_animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        foreach (GameObject gobject in interactables) {

            if (gobject.GetComponent<Lever>() != null) {
                if (!gobject.GetComponent<Lever>().triggered) {
                    CloseDoor();
                    break;
                }
            }

            if (gobject.GetComponent<Button>() != null) {
                if (!gobject.GetComponent<Button>().triggered) {
                    CloseDoor();
                    break;
                }
            }

            if (gobject.GetComponent<Wire>() != null) {
                if (!gobject.GetComponent<Wire>().triggered) {
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
        RunAnimation();
    }

    public void CloseDoor() {
        opened = false;
        boxCollider.isTrigger = false;
        RunAnimation();
    }


    public void RunAnimation() {
        if (opened_previous == opened) {
            return;
        }
        
        opened_previous = opened;

        if (opened) {
            _door_stone_animator.SetTrigger("Opened");
            return;
        }
        _door_stone_animator.SetTrigger("Closed");
    }


}
