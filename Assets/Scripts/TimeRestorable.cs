using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRestorable : MonoBehaviour
{
    private Vector3 _initialPos;
    
    void Start()
    {
        _initialPos = gameObject.GetComponent<Transform>().position;

        TimeManager.NewTimeCycleEvent += _restoreOnNewCycle;
    }

    private void OnDisable()
    {
        TimeManager.NewTimeCycleEvent -= _restoreOnNewCycle;
    }

    private void _restoreOnNewCycle()
    {
        gameObject.GetComponent<Transform>().position = _initialPos;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("killzone")) {
            _restoreOnNewCycle();
        }
    }
}
