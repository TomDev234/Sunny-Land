using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    Text fpsText;
    const float updateInterval = 2f; // Update FPS in seconds
    float frameCount = 0;

    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        GameObject fpsTextObject = GameObject.Find("Text FPS");
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
