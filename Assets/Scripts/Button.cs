using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public bool triggered = false;
    public bool only_box = false;
    public Animator animator;

    private List<String> _currentlyCollided = new List<string>();
    
    private static readonly int IsActive = Animator.StringToHash("isActive");

    private void OnTriggerEnter2D(Collider2D collision) {
        // if (only_box) {
        //     if (collision.CompareTag("Box")) {
        //         triggered = true;
        //         animator.SetBool(IsActive, true);
        //     }
        // } else {
        //     if (collision.CompareTag("Player") || collision.CompareTag("Box") || collision.CompareTag("Shadow")) {
        //         triggered = true;
        //         animator.SetBool(IsActive, true);
        //     }
        // }
        
        if (only_box)
        {
            if (!collision.CompareTag("Box"))
            {
                return;
            }
        }
        else
        {
            if (!collision.CompareTag("Player") && !collision.CompareTag("Box") && !collision.CompareTag("Shadow"))
            {
                return;
            }
        }

        if (!_currentlyCollided.Contains(collision.gameObject.name))
        {
            triggered = true;
            animator.SetBool(IsActive, true);
            _currentlyCollided.Add(collision.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        // if (only_box) { 
        //     if (collision.CompareTag("Box")) {
        //         triggered = false;
        //         animator.SetBool(IsActive, false);
        //     }
        // } else {
        //     if (!collision.CompareTag("Player") || !collision.CompareTag("Shadow"))
        //     {
        //         triggered = false;
        //         animator.SetBool(IsActive, false);
        //     }
        // }
        
        if (only_box)
        {
            if (!collision.CompareTag("Box"))
            {
                return;
            }
        }
        else
        {
            if (!collision.CompareTag("Player") && !collision.CompareTag("Box") && !collision.CompareTag("Shadow"))
            {
                return;
            }
        }

        if (_currentlyCollided.Contains(collision.gameObject.name))
        {
            _currentlyCollided.Remove(collision.gameObject.name);
            if (_currentlyCollided.Count == 0)
            {
                triggered = false;
                animator.SetBool(IsActive, false);
            }
        }
    }
}
