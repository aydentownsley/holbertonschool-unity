using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private string scene;
    private int sceneIndex;

    public void Next()
    {
        // Loads correct next level option for
        // player when they win
        scene = PlayerPrefs.GetString("scene");
        sceneIndex = int.Parse(scene.Substring(5, 2));
        if (sceneIndex <= 2)
        {
            sceneIndex += 1;
            SceneManager.LoadScene("Level0" + sceneIndex);
        }
        else
        {
            sceneIndex = 1;
            SceneManager.LoadScene("MainMenu");
        }

    }
}
