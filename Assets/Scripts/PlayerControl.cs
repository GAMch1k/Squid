using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public Vector2 speed = new Vector2(8, 8);

    public bool can_jump = false;

    public Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update() {
        Vector3 movement = new Vector3(speed.x * Input.GetAxis("Horizontal"), 0, 0);
        movement *= Time.deltaTime;

        transform.Translate(movement);
        
        if (Input.GetKey(KeyCode.Space) && can_jump) {
            can_jump = false;

            Vector2 jump = new Vector2(0, speed.y);

            rb.AddForce(Vector2.up * speed.y, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "platform") {
            can_jump = true;
        }
    }
}
