using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public Vector2 speed = new Vector2(5, 11);
    public Animator animator;
    public ParticleSystem Dust;
    public AudioSource steps;
    public bool can_jump = false;
    private bool _isPlayAud = false;

    public bool blockOnGameOver = false;
    private bool gameOver = false;

    public Rigidbody2D rb;

    private Vector3 _initialPos;
    private Vector3 movement;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        _initialPos = gameObject.GetComponent<Transform>().position;

        TimeManager.NewTimeCycleEvent += _newTimeCycle;
        if (blockOnGameOver)
        {
            TimeManager.GameOverEvent += _gameOver;
        }
    }
    private void Update()
    {
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("run"));
        if (!steps.isPlaying && animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
            steps.Play();
    }
    private void OnDisable()
    {
        TimeManager.NewTimeCycleEvent -= _newTimeCycle;

        if (blockOnGameOver)
        {
            TimeManager.GameOverEvent -= _gameOver;
        }
    }

    private void _newTimeCycle()
    {
        gameObject.GetComponent<Transform>().position = _initialPos;
    }

    private void _gameOver()
    {
        gameOver = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }

    void FixedUpdate() {
        if (gameOver)
        {
            return;
        }

        Vector3 movement = new Vector3(speed.x * Input.GetAxis("Horizontal"), 0, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);

        animator.SetFloat("speed", Mathf.Abs(movement.x));
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
            if (can_jump) {
                can_jump = false; // maybe should delete it
                Dust.Play();

                Vector2 jump = new Vector2(0, speed.y);

                rb.AddForce(Vector2.up * speed.y, ForceMode2D.Impulse);
            }
        }
            
        if (movement.x != 0)
        {
            
            Dust.Play();

        }
        if (movement.x > 0)
        {
            gameObject.transform.localScale = new Vector3(
                MathF.Abs(gameObject.transform.localScale.x), 
                MathF.Abs(gameObject.transform.localScale.y), 
                MathF.Abs(gameObject.transform.localScale.z));
        }
        if (movement.x < 0)
        {
            gameObject.transform.localScale = new Vector3(
                MathF.Abs(gameObject.transform.localScale.x) * -1,
                MathF.Abs(gameObject.transform.localScale.y),
                MathF.Abs(gameObject.transform.localScale.z));
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "platform") {
            can_jump = true;
            animator.SetBool("isJumping", false);
        }
        if (collision.tag == "killzone")
        {
            _newTimeCycle(); 
        }
    }

    private IEnumerator wait(int sec) 
    {
        yield return new WaitForSeconds(sec);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag != "platform" 
            && collision.tag != "Box" 
            && collision.tag != "Untagged"
            && collision.tag != "Shadow"
            && collision.tag != "Box")
        {
            can_jump = false;
            animator.SetBool("isJumping", true);
        }
    }
}
