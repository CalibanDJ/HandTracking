using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{

    [SerializeField]
    public GameObject placedPrefab;

    private GameObject spawnPrefab;
    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(index: 0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(arRaycastManager.Raycast(touchPosition, hits, trackableTypes: TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if (spawnPrefab == null)
                spawnPrefab = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            else
                spawnPrefab.transform.position = hitPose.position;
        }
    }
}
