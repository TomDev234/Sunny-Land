using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    Text fpsText;
    const int targetFramerate = 60;
    const float updateInterval = 2f; // Update FPS in seconds
    float frameCount = 0;

    private void Start()
    {
        Application.targetFrameRate = targetFramerate;
        GameObject fpsTextObject = GameObject.Find(Tags.FPS_TEXT);
        fpsText = fpsTextObject.GetComponent<Text>();
        InvokeRepeating("UpdateFPS", 0f, updateInterval);
    }

    private void Update()
    {
        frameCount++;
    }

    private void UpdateFPS()
    {
        float fps = frameCount / updateInterval;
        frameCount = 0;
        fpsText.text = "FPS: " + Mathf.RoundToInt(fps);
    }
}
