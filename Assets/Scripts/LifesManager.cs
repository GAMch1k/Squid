using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifesManager : MonoBehaviour {

    private TimeManager _timeManager;

    public GameObject fullClockImage;
    public GameObject emptyClockImage;

    float pos_x, pos_y;
    float img_width, img_height;
    int maxHealth;

    private GameObject _full_img;


    void Start() {
        TimeManager.NewTimeCycleEvent += _decreaseHealth;
        TimeManager.GameOverEvent += GameOver;

        pos_x = fullClockImage.GetComponent<RectTransform>().position.x;
        pos_y = fullClockImage.GetComponent<RectTransform>().position.y;

        img_width = fullClockImage.GetComponent<RectTransform>().rect.width;
        img_height = fullClockImage.GetComponent<RectTransform>().rect.height;
        
        _timeManager = GameObject.FindWithTag("timemanager").GetComponent<TimeManager>();
        maxHealth = _timeManager.GetMaxTimeCycles();
        
        ResetHealthBar();
    }


    void GameOver() {

    }

    private void OnDisable()
    {
        TimeManager.NewTimeCycleEvent -= _decreaseHealth;
        TimeManager.GameOverEvent -= GameOver;

    }

    private void _decreaseHealth() {

        if(_timeManager.GetCurrentRun() == 0) { return; }

        _full_img.transform.position = new Vector3(pos_x * (maxHealth - _timeManager.GetCurrentRun()), pos_y, 0);
        _full_img.GetComponent<RectTransform>().sizeDelta = new Vector2(img_width * (maxHealth - _timeManager.GetCurrentRun()), img_height);
    }


    public void ResetHealthBar() {
        
        _full_img = Instantiate(fullClockImage);
        _full_img.transform.parent = transform;
        _full_img.transform.position = new Vector3(pos_x * maxHealth, pos_y, 0);
        _full_img.GetComponent<RectTransform>().sizeDelta = new Vector2(img_width * maxHealth, img_height);

        var empty_img = Instantiate(emptyClockImage);
        empty_img.transform.parent = transform;
        empty_img.transform.position = new Vector3(pos_x * maxHealth, pos_y, 0);
        empty_img.GetComponent<RectTransform>().sizeDelta = new Vector2(img_width * maxHealth, img_height);

    }

}
