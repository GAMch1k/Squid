using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour {
    private int _currentRun = -1;
    private int _currentTick;

    public int levelTimeSeconds = 3;
    private int _levelTimeTicks;

    private Transform _initialPlayerPos; // replace with pos tracking

    public delegate void OnNewTimeCycle();

    public static OnNewTimeCycle NewTimeCycleEvent;

    private void _NewTimeCycle()
    {
        _currentRun++;
        _currentTick = 0;
        
        NewTimeCycleEvent?.Invoke();
    }

    public int GetCurrentTick()
    {
        return _currentTick;
    }

    public int GetCurrentRun()
    {
        return _currentRun;
    }

    public int GetSecondsRemaining()
    {
        return (int)((_levelTimeTicks - _currentTick) / 50.0);
    }

    void Start()
    {
        _initialPlayerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _levelTimeTicks = levelTimeSeconds * 50;
        _NewTimeCycle();
    }

    void FixedUpdate()
    {
        _currentTick++;
        if (_currentTick >= _levelTimeTicks)
        {
            _NewTimeCycle();
        }
    }

    void Update()
    {
        if (_currentTick < 25)
        {
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            _NewTimeCycle();
        }
    }
}
