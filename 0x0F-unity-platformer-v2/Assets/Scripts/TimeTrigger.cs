using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrigger : MonoBehaviour
{
    public GameObject player;

    void OnTriggerExit()
    {
        player.GetComponent<Timer>().enabled = true;
    }

}
