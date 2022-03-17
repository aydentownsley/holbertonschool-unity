using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class audio_trigger : MonoBehaviour
{
    public AudioClip grass;
    public AudioClip rock;
    public AudioClip grass_land;
    public AudioClip rock_land;
    public GameObject Player;
    string surface = "rock";

    void Start()
    {
        Player.GetComponent<AudioSource>().clip = rock;
    }

    void Update()
    {
        float bf = Input.GetAxis("Vertical");
        float s2s = Input.GetAxis("Horizontal");

        // Checks if player is moving,
        // then checks for material to play apporpriate sound
        if ((bf != 0 || s2s != 0) && Player.GetComponent<StarterAssets.ThirdPersonController>().Grounded == true)
        {
            if (surface == "grass")
            {
                Player.GetComponent<AudioSource>().clip = grass;
            }
            else if (surface == "rock")
            {
                Player.GetComponent<AudioSource>().clip = rock;
            }
            if (!Player.GetComponent<AudioSource>().isPlaying)
                Player.GetComponent<AudioSource>().Play();
        }
        else if ((bf == 0 && s2s == 0) && Player.GetComponent<StarterAssets.ThirdPersonController>().Grounded == true)
        {
            Player.GetComponent<AudioSource>().Stop();
        }
    }

    // Plays correct landing sound depending on surface of collider
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Rock")
        {
            surface = "rock";
        }
        else if (col.gameObject.tag == "Grass")
        {
            surface = "grass";
        }
        if (surface == "grass")
        {
            Player.GetComponent<AudioSource>().clip = grass_land;
            StartCoroutine(waitForSound(col));
        }
        else if (surface == "rock")
        {
            Player.GetComponent<AudioSource>().clip = rock_land;
            StartCoroutine(waitForSound(col));
        }
    }

    // Stops sounds from playing when player is moving
    // but in the air (falling or jumping)
    void OnTriggerExit(Collider col)
    {
        Player.GetComponent<AudioSource>().Stop();
    }

    IEnumerator waitForSound(Collider other)
    {
        Player.GetComponent<AudioSource>().Play();
        //Wait Until Sound has finished playing
        while (Player.GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }
    }
}
