using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireProjectile : MonoBehaviour
{
    public Camera cam;

    private Vector3 startDrag;
    private Vector3 endDrag;

    public GameObject start;
    public GameObject searching;
    public GameObject Red;
    public GameObject GameOver;
    public GameObject Retry;

    public GameObject ammo_prefab;
    public GameObject ammo;
    private Rigidbody ammo_rb;

    public float ForceMult = 3;
    public float fowared_dist;
    public float down_dist;
    private bool midFire = false;
    private bool dragging = true;
    private int ammoCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(false);
        Load();
    }

    // Update is called once per frame
    void Update()
    {

        if (dragging || !midFire)
            ammo.transform.position = cam.transform.position + (cam.transform.forward * fowared_dist) + (-cam.transform.up * down_dist);

        if (ammoCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ammo.GetComponent<Material>().color = Color.green;
                startDrag = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                dragging = false;
                endDrag = Input.GetTouch(0).position;
                Fire(startDrag-endDrag);
                ammo.GetComponent<Material>().color = Color.red;
            }

            if (ammo.transform.position.y < -1)
            {
                Destroy(ammo);
                Load();
                midFire = false;
                dragging = true;
            }
        }
        else
        {
            searching.GetComponent<Text>().text = "OUT OF AMMO!";
            Red.SetActive(true);
            GameOver.SetActive(true);
            Retry.SetActive(true);
        }
    }

    void Load()
    {
        ammo = Instantiate(ammo_prefab, cam.transform.position + (cam.transform.forward * fowared_dist) + (-cam.transform.up * down_dist), cam.transform.rotation);
    }

    void Fire(Vector3 direction)
    {
        if(midFire)
            return;

        if (ammoCount > 0)
        {
            ammoCount--;
            searching.GetComponent<Text>().text = "Ammo: " + ammoCount;
        }
        midFire = true;
        ammo_rb = ammo.AddComponent<Rigidbody>();
        ammo_rb.AddForce(cam.transform.forward * ForceMult);
    }

    void OnCollisionEnter(Collision other)
    {
        searching.GetComponent<Text>().text = other.gameObject.name;
        if (other.gameObject.tag == "target" || other.gameObject.tag == "plane")
        {
            Destroy(ammo);
            midFire = false;
            dragging = true;
            Load();
        }
    }
}
