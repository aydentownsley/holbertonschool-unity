using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume_SFX : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider SFX;
    float value = 1;

    void Start()
    {
        SFX.value = PlayerPrefs.GetFloat("SFX_Volume", value);
    }

    public void SetLevel(float slider_value)
    {
        PlayerPrefs.SetFloat("SFX_Volume", slider_value);
        Mixer.SetFloat("SFX_Run", Mathf.Log10(slider_value) * 20);
        Mixer.SetFloat("SFX_Land", Mathf.Log10(slider_value) * 20);
        Mixer.SetFloat("SFX_Amb", Mathf.Log10(slider_value) * 20);

    }
}
