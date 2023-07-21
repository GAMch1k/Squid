using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public Vector2 speed = new Vector2(5, 11);

    public bool can_jump = false;

    public Rigidbody2D rb;

    private Vector3 _initialPos;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        _initialPos = gameObject.GetComponent<Transform>().position;

        TimeManager.NewTimeCycleEvent += _newTimeCycle;
    }

    private void OnDisable()
    {
        TimeManager.NewTimeCycleEvent -= _newTimeCycle;
    }

    private void _newTimeCycle()
    {
        gameObject.GetComponent<Transform>().position = _initialPos;
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(speed.x * Input.GetAxis("Horizontal"), 0, 0);
        movement *= Time.deltaTime;

        transform.Translate(movement);
        
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
            if (can_jump) {
                can_jump = false; // maybe should delete it

                Vector2 jump = new Vector2(0, speed.y);

                rb.AddForce(Vector2.up * speed.y, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "platform" || collision.tag == "Box") {
            can_jump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        can_jump = false;
    }
}
