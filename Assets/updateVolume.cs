using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class updateVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void setLevel(float sliderVolume) { 
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderVolume)*20);
    }
}
