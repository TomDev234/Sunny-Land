using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    Animator animator;
    float transitionTime = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.PLAYER_TAG))
        {
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
        if (animator != null)
            animator.SetTrigger(Tags.START_PARAMETER);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }
}
