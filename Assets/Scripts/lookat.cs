using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GameObject.Find("Main Camera").transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.Find("Main Camera").transform.position); 
    }
}
