using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTheater : MonoBehaviour
{
    private TimeManager _timeManager;
    private Transform _playerTransform;
    private GameObject _shadowPrefab;
    
    private List<GameObject> _shadows = new List<GameObject>();
    private List<List<Vector3>> _phantomTraces = new List<List<Vector3>>(); // replace with pos tracking
    private bool _recordNewTraces;

    void Start()
    {
        _recordNewTraces = true;
        _timeManager = GameObject.FindWithTag("timemanager").GetComponent<TimeManager>();
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _shadowPrefab = Resources.Load("Prefabs/ShadowActor") as GameObject;
    }

    void FixedUpdate()
    {
        var currentTick = _timeManager.GetCurrentTick();
        var currentRun = _timeManager.GetCurrentRun();

        for (int i = 0; i < _shadows.Count; i++)
        {
            if (_phantomTraces[i].Count < currentTick)
            {
                continue;
            }
            _shadows[i].GetComponent<Transform>().position = _phantomTraces[i][currentTick];
        }

        if (_recordNewTraces)
        {
            var playerPos = _playerTransform.position;
            _phantomTraces[currentRun].Add(playerPos);
            if (_phantomTraces[currentRun].Count != currentTick + 1)
            {
                Debug.Log("phantomtraces array len error");
            }
        }

    }

    public void NewTimeCycle(bool isFinal)
    {
        var currentRun = _timeManager.GetCurrentRun();
        if (currentRun > 0)
        {
            _shadowReplay();
        }
        
        if (isFinal)
        {
            _recordNewTraces = false;
        }

        List<Vector3> whiteTemplate = new List<Vector3>();
        _phantomTraces.Add(whiteTemplate);
        
    }

    private void _shadowReplay()
    {
        GameObject newShadow = Instantiate(_shadowPrefab);
        Debug.Log("created new shadow");
        newShadow.transform.parent = gameObject.transform;
        _shadows.Add(newShadow);
    }
}