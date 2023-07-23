using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)), ForceMode2D.Impulse);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.AddForce(new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)), ForceMode2D.Impulse);
        }
    }
}
