using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TimeManager _timeManager;
    private int _minutes = 0;
    private int _seconds = 0;

    void Start()
    {
        _timeManager = GameObject.FindWithTag("timemanager").GetComponent<TimeManager>();
    }
    
    
    void Update()
    {
        _seconds = _timeManager.GetSecondsRemaining();
        _minutes = _seconds / 60;
        _seconds = _seconds % 60;
        string sminutes;
        string sseconds;

        if (_minutes < 10)
        {
            sminutes = "0" + _minutes.ToString();
        }
        else
        {
            sminutes = _minutes.ToString();
        }
        
        if (_seconds < 10)
        {
            sseconds = "0" + _seconds.ToString();
        }
        else
        {
            sseconds = _seconds.ToString();
        }
        string kek = sminutes + ":" + sseconds;

        gameObject.GetComponent<TextMeshProUGUI>().text = "до пробуждения: " + kek;
    }
}
