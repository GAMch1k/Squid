using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    List<Transform> phantom_position = new List<Transform>();
    public bool first_run = true;

    int tick = 0;

    void Start() {
        
    }



    void FixedUpdate() {
        if (first_run) {
            phantom_position.Add(GameObject.FindWithTag("Player").GetComponent<Transform>());
            Debug.Log(phantom_position[^1].position.x);
        } else {
            GameObject.FindWithTag("Player").GetComponent<Transform>().position = phantom_position[tick].position;
            tick++;
        }
        
    }
}
