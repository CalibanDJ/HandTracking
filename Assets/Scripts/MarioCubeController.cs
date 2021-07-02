using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class MarioCubeController : MonoBehaviour
{
    private ManoGestureContinuous grab;
    private ManoGestureContinuous pinch;
    private ManoGestureTrigger click;
    
    [SerializeField]
    public GameObject cube;

    private GameObject spawnPrefab;

    private string handTag = "Player";
    private Renderer cubeRenderer;
    

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        grab = ManoGestureContinuous.CLOSED_HAND_GESTURE;
        pinch = ManoGestureContinuous.HOLD_GESTURE;
        click = ManoGestureTrigger.CLICK;
        cubeRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        SpawnWhenClicking();
    }
    

    /// <summary>
    /// Spawn when clicking
    /// </summary>
    private void SpawnWhenClicking()
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_trigger == click)
        {
            if (spawnPrefab == null)
                spawnPrefab = Instantiate(cube, new Vector3(transform.position.x, transform.position.y + (transform.localScale.y * 10), transform.position.z), Quaternion.identity);
            else
                spawnPrefab.transform.position = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y * 10), transform.position.z);
        }
    }
    




}