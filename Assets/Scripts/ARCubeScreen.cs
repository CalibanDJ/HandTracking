using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCubeScreen : MonoBehaviour
{
    [SerializeField]
    private Material[] arCubeMaterial;
    

    private string handTag = "Player";
    private Renderer cubeRenderer;


    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        cubeRenderer = GetComponent<Renderer>();
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
            this.GetComponent<Screenshot>().TakeAShot();
        }
    }
}