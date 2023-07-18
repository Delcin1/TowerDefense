using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, bool destroyed = false)
    {
        if (destroyed)
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, PlayerPrefs.GetFloat("volume", 1));
        else
            audioSrc.PlayOneShot(clip, PlayerPrefs.GetFloat("volume", 1));
    }
}
