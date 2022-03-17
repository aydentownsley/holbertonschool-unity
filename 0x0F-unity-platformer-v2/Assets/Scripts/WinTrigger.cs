using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public Timer time_script;
    public Text timetext;
    public GameObject WinCanvas;
    public Text WinText;
    public AudioSource BGM;
    public AudioSource Steps;
    public AudioSource Win;


    void OnTriggerEnter()
    {
        BGM.Stop();
        Steps.Stop();
        Win.Play();
        Time.timeScale = 0f;
        timetext.fontSize = 60;
        timetext.color = Color.green;
        time_script.enabled = false;
        WinText.text = timetext.text;
        WinCanvas.SetActive(true);
        BGM.Stop();
        Steps.Stop();
    }
}
