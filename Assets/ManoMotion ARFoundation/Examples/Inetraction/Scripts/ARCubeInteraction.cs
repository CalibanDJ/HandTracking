using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCubeInteraction : MonoBehaviour
{
    [SerializeField]
    private Material[] arCubeMaterial;
    [SerializeField]
    private GameObject smallCube;


    public GameObject ARCam;

    private string handTag = "Player";
    private Renderer cubeRenderer;


    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.sharedMaterial = arCubeMaterial[0];
        cubeRenderer.material = arCubeMaterial[0];
    }

    private void Update()
    {
        this.gameObject.transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z));
    }


    /// <summary>
    /// Vibrate when hand collider enters the cube.
    /// </summary>
    /// <param name="other">The collider that enters</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == handTag)
        {
            cubeRenderer.sharedMaterial = arCubeMaterial[1];
            Handheld.Vibrate();
        }
    }

    /// <summary>
    /// Change material when exit the cube
    /// </summary>
    /// <param name="other">The collider that exits</param>
    private void OnTriggerExit(Collider other)
    {
        cubeRenderer.sharedMaterial = arCubeMaterial[0];
    }
}