using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    private float BGM;
    private float SFX;
    public AudioMixer Mixer;
    public InputActionAsset actions;
    // Start is called before the first frame update
    void Start()
    {
        BGM = PlayerPrefs.GetFloat("SFX_Volume");
        SFX = PlayerPrefs.GetFloat("BGM_Volume");
        Mixer.SetFloat("SFX_Run", Mathf.Log10(SFX) * 20 - 20);
        Mixer.SetFloat("SFX_Land", Mathf.Log10(SFX) * 20 + 2);
        Mixer.SetFloat("SFX_Amb", Mathf.Log10(SFX) * 20 + 5);
        Mixer.SetFloat("BGM", Mathf.Log10(BGM) * 20);

        var rebinds = PlayerPrefs.GetString("rebinds");
        actions.LoadBindingOverridesFromJson(rebinds);
    }

    public void LoadLevel01()
    {
        SceneManager.LoadScene("Level01");
    }

    public void LoadLevel02()
    {
        SceneManager.LoadScene("Level02");
    }

    public void LoadLevel03()
    {
        SceneManager.LoadScene("Level03");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
