using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public static AudioFX instance;
    public AudioClip[] audioClips;
    AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void Play(int i)
    {
        Debug.Log("AudioFX Play " + i);
        audioSource.PlayOneShot(audioClips[i]);
    }

    public void Play(int i, out float length)
    {
        audioSource.PlayOneShot(audioClips[i]);
        length = audioClips[i].length;
    }

    public void PlayClip(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
