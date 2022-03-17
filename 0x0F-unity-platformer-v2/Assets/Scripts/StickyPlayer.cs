using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("moving");
            other.gameObject.transform.position = transform.position;
        }
    }
}
