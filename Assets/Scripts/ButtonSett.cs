using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSett : MonoBehaviour
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
        ExecuteTrigger("set");

    }
    public void onMenuExtendNo()
    {
        button3.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);
        button3.GetComponent<Animator>().SetTrigger("Normal");
        ExecuteTrigger("def");
    }
}
