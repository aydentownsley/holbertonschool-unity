using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume_BGM : MonoBehaviour
{
    public AudioMixer Mixer;

    public void SetLevel(float slider_value)
    {
        Mixer.SetFloat("BGM", Mathf.Log10(slider_value) * 20);
    }
}
