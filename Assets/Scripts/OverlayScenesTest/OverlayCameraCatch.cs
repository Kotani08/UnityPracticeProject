using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayCameraCatch : MonoBehaviour
{
    public Camera camera;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        this.gameObject.GetComponent<Canvas>().worldCamera = camera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
