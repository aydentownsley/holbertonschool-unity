 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector3 startposition = new Vector3(0, 25, 0);
    private bool yAxis = false;
    public GameObject player;
    public GameObject Freelook;
    public GameObject Movement;

    private void Start()
    {
        // Gets current scene, so player can return to correct scene
        // if they use a scene menu
        PlayerPrefs.SetString("scene", SceneManager.GetActiveScene().name);
        if (PlayerPrefs.GetInt("yAxis") == 1)
            yAxis = true;
        else
            yAxis = false;

        GameObject.Find("Freelook").GetComponent<CinemachineFreeLook>().m_YAxis.m_InvertInput = yAxis;
    }

    // Turns of camera controll when player falls
    void FixedUpdate()
    {
        if (transform.position.y < -25)
        {
            Freelook.GetComponent<CinemachineFreeLook>().enabled = false;
            gameObject.GetComponent<CharacterController>().enabled = false;
            transform.position = startposition;
            Freelook.GetComponent<CinemachineFreeLook>().enabled = true;
            gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }

    // Lets player "stick" to moving platforms
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("moving"))
        {
            player.transform.SetParent(other.gameObject.transform, true);
        }
    }

    // Return transform to normal when hopping off of moving platforms
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("moving"))
        {
            player.transform.SetParent(null);
        }
    }

}
