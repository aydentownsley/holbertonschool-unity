using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class KeyBindingMenu : MonoBehaviour
{
    public InputActionAsset actions;

    void Awake()
    {
        var rebinds = PlayerPrefs.GetString("rebinds");
        actions.LoadBindingOverridesFromJson(rebinds);
        Time.timeScale = 1;
    }

    public void Back()
    {
        SceneManager.LoadScene("Options");
    }

    public void Apply()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("rebinds", rebinds);
    }
}
