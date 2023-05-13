using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
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
    }
}
