using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    List<Transform> phantom_position = new List<Transform>();
    bool first_run = true;

    void Start() {
        
    }



    void FixedUpdate() {
        if (first_run) {
            phantom_position.Add(GameObject.FindWithTag("Player").GetComponent<Transform>());
        } else {

        }
        
    }
}
