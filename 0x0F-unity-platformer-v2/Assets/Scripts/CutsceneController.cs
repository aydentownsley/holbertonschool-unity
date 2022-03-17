using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneController : MonoBehaviour
{
    public GameObject TimerCanvas;
    public GameObject CutSceneCamera;
    public GameObject Freelook;

    void Start()
    {
        Freelook.SetActive(false);
    }

    void Update()
    {
        // When cutscene is playing removes ability to move player
        // So player starts at beginning. Only allows movement
        // once cutscene is finished
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            TimerCanvas.SetActive(true);
            Freelook.SetActive(true);
            Freelook.GetComponent<CinemachineFreeLook>().m_YAxis.Value = 0.45f;
            Freelook.GetComponent<CinemachineFreeLook>().m_XAxis.Value = 0;
            CutSceneCamera.SetActive(false);
            GameObject.Find("Player").GetComponent<CharacterController>().enabled = true;
        }
    }
}
