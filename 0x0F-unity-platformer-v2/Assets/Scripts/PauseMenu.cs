using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool paused = false;
    private string scene;
    private int sceneIndex;
    public AudioMixerSnapshot audio_paused;
    public AudioMixerSnapshot audio_unpaused;

    // Starts timer when script enabled
    void OnEnable()
    {
        Time.timeScale = 1;
        Debug.Log("scene loaded");
    }

    void Update()
    {
        // Checks for escape key and handles wether
        // game should pause or resume ("stops time")
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;

            if (paused)
            {
                AcvivateMenu();
                audio_paused.TransitionTo(0.01f);
            }
            else
            {
                DeactivateMenu();
                audio_unpaused.TransitionTo(0.01f);
            }
        }

        if (!paused)
            audio_unpaused.TransitionTo(0.01f);

    }

    // enables pause menu
    public void AcvivateMenu()
    {
        paused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    // disables pause menu
    public void DeactivateMenu()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    // Loads Options Scene
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // Resumes time and transitions audio
    public void Resume()
    {
        paused = false;
        Debug.Log("Resume");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        audio_unpaused.TransitionTo(0.01f);
    }

    // Restarts scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    // Loads main menu Scene
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
