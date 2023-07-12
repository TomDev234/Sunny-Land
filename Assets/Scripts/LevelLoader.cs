using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    AudioSource audioSource, musicAudioSource;
    float transitionTime = 2f;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicAudioSource = GameObject.Find("MusicAudioSource").GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.PLAYER))
        {
            musicAudioSource.Stop();
            audioSource.Play();
            GemBehaviourScript.gemsCollected = 0;
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int index)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }
}
