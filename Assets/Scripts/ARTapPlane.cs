using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARTapPlane : MonoBehaviour
{
    // Start is called before the first frame update

    private ARRaycastManager arRaycastManager;
    private Vector2 touchpos;
    public bool touched;
    static List<ARRaycastHit> hitlist = new List<ARRaycastHit>();
    public GameObject infplane;
    ARPlaneManager arpm;
    public GameObject scanPanel;
    public GameObject preGamePanel;
    public GameObject ARCam;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        touched = false;
        arpm = FindObjectOfType<ARPlaneManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchpos)
    {
        if (Input.touchCount > 0)
        {
            touchpos = Input.GetTouch(0).position;
            return true;
        }
        touchpos = default;
        return false;


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touched == false)
        {
            if (!TryGetTouchPosition(out Vector2 touchpos))
                return;
            if (arRaycastManager.Raycast(touchpos, hitlist, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hitlist[0].pose;

                //Object.Instantiate(infplane, hitPose.position, hitPose.rotation);  
                Object.Instantiate(infplane, ARCam.transform.position, hitPose.rotation);
                touched = true;
                scanPanel.SetActive(false);
                preGamePanel.SetActive(true);
                foreach (var plane in arpm.trackables)
                plane.gameObject.SetActive(false);
                
                
            }
        }
        else
        {
            foreach (var plane in arpm.trackables)
                plane.gameObject.SetActive(false);
        }
    }
}
