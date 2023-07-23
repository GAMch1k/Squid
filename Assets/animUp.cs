using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public void upObject() {
        animator.SetTrigger("up");
    }
}
