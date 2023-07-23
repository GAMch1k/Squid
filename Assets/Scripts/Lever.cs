using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour {
    public bool triggered = false;
    public Animator animator;
    public AudioSource audio;

    private List<String> _currentlyCollided = new List<string>();
    
    private static readonly int IsActive = Animator.StringToHash("isActive");

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Shadow")) {
            if (!_currentlyCollided.Contains(collision.gameObject.name))
            {
                audio.Play();
                triggered = true;
                animator.SetBool(IsActive, true);
                _currentlyCollided.Add(collision.gameObject.name);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_currentlyCollided.Contains(collision.gameObject.name))
        {
            _currentlyCollided.Remove(collision.gameObject.name);
            if (_currentlyCollided.Count == 0)
            {
                audio.Play();
                triggered = false;
                animator.SetBool(IsActive, false);
            }
        }
    }
}
