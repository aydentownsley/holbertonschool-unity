using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlaneManager : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    [SerializeField]
    ARPlaneManager m_PlaneManager;

    public static ARPlane chosenPlane;

    // Game Items
    public Button start;
    public GameObject targetPrefab;
    public GameObject playfieldPrefab;
    public GameObject searching;
    private bool foundPlane = false;
    public GameObject playfield;
    public List<GameObject> targets = new List<GameObject>();
    private bool planeCheck = false;

    private int targetCount = 0;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    void Update()
    {
        if (planeCheck == false)
        {
            if (m_PlaneManager.trackables.count > 0)
            {
                searching.GetComponent<Text>().text = "Please Select a Plane";
                planeCheck = true;
            }
        }

        if (Input.touchCount == 0)
            return;

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (foundPlane == false)
            {
                foundPlane = true;
                chosenPlane = handleRaycast(m_Hits[0]);
                createField();
                start.gameObject.SetActive(true);
            }
        }

    }

    ARPlane handleRaycast(ARRaycastHit hit)
    {
        if ((hit.hitType & TrackableType.Planes) != 0)
        {
            var hitplane = m_PlaneManager.GetPlane(hit.trackableId);
            foreach (var plane in m_PlaneManager.trackables)
            {
                if (plane != hitplane)
                    plane.gameObject.SetActive(false);
            }
            m_PlaneManager.enabled = false;
            return hitplane;
        }

        return null;
    }

    public void createField()
    {
        searching.GetComponent<Text>().text = "Ammo: 5";
        playfield = Instantiate(playfieldPrefab, chosenPlane.transform.position, Quaternion.identity);
        chosenPlane.gameObject.SetActive(false);
        while (targetCount < 5)
        {
            targets.Add(Instantiate(targetPrefab, randomPoint(playfield), Quaternion.identity));
            targetCount++;
        }
    }

    public Vector3 randomPoint(GameObject plane)
    {
        Vector3 randomPoint = new Vector3(Random.Range(plane.transform.position.x - 0.25f, plane.transform.position.x + 0.25f),
                                          plane.transform.position.y + 0.07f,
                                          Random.Range(plane.transform.position.z - 0.25f, plane.transform.position.z + 0.25f));
        return randomPoint;
    }
}
