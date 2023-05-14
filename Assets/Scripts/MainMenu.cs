using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public static void StartGame()
    {
        SceneManager.LoadScene("Scene 01");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
