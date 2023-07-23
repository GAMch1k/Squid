using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playbtnreal : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    public void startPlay()
    {
        audio.Play();
    }
    public void exitGame() {
        audio.Play();
        Application.Quit();
    }
}
