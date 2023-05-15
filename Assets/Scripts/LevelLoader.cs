using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.PLAYER_TAG))
        {
            if (SceneManager.GetActiveScene().name == "Scene 01")
            {
                GemBehaviourScript.gemsCollected = 0;
                SceneManager.LoadScene("Scene 02");
            }
            else if (SceneManager.GetActiveScene().name == "Scene 02")
            {
                GemBehaviourScript.gemsCollected = 0;
                SceneManager.LoadScene("Scene 03");
            }
            else if (SceneManager.GetActiveScene().name == "Scene 03")
            {
                GemBehaviourScript.gemsCollected = 0;
                SceneManager.LoadScene("Win");
            }
        }
    }
}
