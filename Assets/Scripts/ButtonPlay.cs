using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour
{
    public GameObject menu;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    private void ExecuteTrigger(string trigger)
    {
        if (menu != null)
        {
            var animator = menu.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(trigger);
            }
        }
    }

    public void onMenuExtendYes()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(true);
        ExecuteTrigger("set");

    }
    public void onMenuExtendNo()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.GetComponent<Animator>().SetTrigger("Normal");
        ExecuteTrigger("def");
        button3.SetActive(false);

    }
}
