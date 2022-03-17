using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text Timer_Text;
    public float time = 0f;

    public void format_time(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        int fraction = (int)((time * 100) % 100);
        Timer_Text.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        format_time(time);
    }
}
