using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class updateVolumeSFX : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audio;

    public void setLevel(float sliderVolume)
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderVolume) * 20);
        audio.Play();
    }
}
