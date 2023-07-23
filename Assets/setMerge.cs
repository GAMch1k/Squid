using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class setMerge : MonoBehaviour
{

    public AudioSource audio;
    public AudioSource audio1;
    public AudioClip clip;
    public void setMerges()
    {
        audio = GetComponent<AudioSource>();
        audio.loop = false;
        StartCoroutine(waitForSound(audio1, clip));

    }

    IEnumerator waitForSound(AudioSource other, AudioClip clip)
    {
        while (audio.isPlaying)
        {
            yield return null;
        }
        Debug.Log("asdasdasd");
        other.Play();
    }
}
