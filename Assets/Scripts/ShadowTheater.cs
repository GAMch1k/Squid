using System.Collections.Generic;
using UnityEngine;

public class ShadowTheater : MonoBehaviour
{
    private TimeManager _timeManager;
    private Transform _playerTransform;
    private GameObject _shadowPrefab;
    
    private List<GameObject> _shadows = new List<GameObject>();
    private List<List<Vector3>> _phantomTraces = new List<List<Vector3>>();
    private bool _recordNewTraces;

    private void Start()
    {
        _recordNewTraces = true;
        _timeManager = GameObject.FindWithTag("timemanager").GetComponent<TimeManager>();
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _shadowPrefab = Resources.Load("Prefabs/ShadowActor") as GameObject;

        TimeManager.NewTimeCycleEvent += _newTimeCycle;
        TimeManager.GameOverEvent += _stopNewRecordings;
    }

    private void OnDisable()
    {
        TimeManager.NewTimeCycleEvent -= _newTimeCycle;
        TimeManager.GameOverEvent -= _stopNewRecordings;
    }

    private void FixedUpdate()
    {
        var currentTick = _timeManager.GetCurrentTick();
        var currentRun = _timeManager.GetCurrentRun();

        for (int i = 0; i < _shadows.Count; i++)
        {
            if (_phantomTraces[i].Count <= currentTick)
            {
                continue;
            }
            _shadows[i].GetComponent<Transform>().position = _phantomTraces[i][currentTick];
        }

        if (!_recordNewTraces) return;
        var playerPos = _playerTransform.position;
        _phantomTraces[currentRun].Add(playerPos);

    }

    private void _newTimeCycle()
    {
        var currentRun = _timeManager.GetCurrentRun();
        if (currentRun > 0)
        {
            GameObject newShadow = Instantiate(_shadowPrefab, gameObject.transform);
            _shadows.Add(newShadow);
        }

        List<Vector3> whiteTemplate = new List<Vector3>();
        _phantomTraces.Add(whiteTemplate);
    }

    private void _stopNewRecordings()
    {
        _recordNewTraces = false;
    }
}