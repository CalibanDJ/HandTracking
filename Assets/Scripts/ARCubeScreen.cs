using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCubeScreen : MonoBehaviour
{
    [SerializeField]
    private Mesh[] arCubeMesh;

    private string handTag = "Player";
    private Renderer cubeRenderer;

    private MeshFilter meshFilter;


    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        cubeRenderer = GetComponent<Renderer>();
        meshFilter = this.GetComponent<MeshFilter>();
    }

    private void Update()
    {
        //this.gameObject.transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z));
    }


    /// <summary>
    /// Vibrate when hand collider enters the cube.
    /// </summary>
    /// <param name="other">The collider that enters</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == handTag)
        {
            Debug.Log("Screened !!!!");
            meshFilter.sharedMesh = arCubeMesh[1];
            this.GetComponent<Screenshot>().TakeAShot();
        }
    }

    /// <summary>
    /// Change material when exit the cube
    /// </summary>
    /// <param name="other">The collider that exits</param>
    private void OnTriggerExit(Collider other)
    {
        meshFilter.sharedMesh = arCubeMesh[0];
    }
}