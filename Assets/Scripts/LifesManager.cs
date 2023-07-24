using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesManager : MonoBehaviour {

    private TimeManager _timeManager;

    public GameObject fullClockImage;
    public GameObject emptyClockImage;

    Sprite emptyClockSprite;

    int maxHealth;
    int healthLeft;

    public List<GameObject> healthBar;

    void Start() {
        TimeManager.NewTimeCycleEvent += _decreaseHealth;
        emptyClockSprite = Resources.Load<Sprite>("Sprites/Environment/clock-empty.png");


        _timeManager = GameObject.FindWithTag("timemanager").GetComponent<TimeManager>();
        maxHealth = _timeManager.GetMaxTimeCycles();
        healthLeft = maxHealth - _timeManager.GetCurrentRun();


        float pos_x = fullClockImage.GetComponent<RectTransform>().position.x;
        float pos_y = fullClockImage.GetComponent<RectTransform>().position.y;
        float img_width = fullClockImage.GetComponent<RectTransform>().rect.width;

        for (int i = 0; i < maxHealth; i++) {

            var _full_img = Instantiate(fullClockImage);
            _full_img.transform.parent = transform;

            _full_img.transform.position = new Vector3(pos_x + img_width * i, pos_y, 0);

            var _empty_img = Instantiate(emptyClockImage);
            _empty_img.transform.parent = transform;

            _empty_img.transform.position = new Vector3(pos_x + img_width * i, pos_y, 0);



            healthBar.Add(_full_img);

        }
    }


    void FixedUpdate() {
        
    }

    private void _decreaseHealth() {

        if(_timeManager.GetCurrentRun() == 0) { return; }

        if (healthBar.Count > 0) {

            for (int i = 0; i < maxHealth - _timeManager.GetCurrentRun(); i++) { 
                healthBar[healthBar.Count - i].gameObject.active = false;
            }

            

        }
    }

}
