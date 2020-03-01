using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
   
    [SerializeField]
    private float cameraXaxis;
    private float cameraYaxis;
    void Start()
    {
        this.gameObject.transform.position = new Vector2(cameraXaxis, cameraYaxis);
    }


    void Update()
    {
        cameraXaxis = cameraXaxis + (0.2f * Time.deltaTime);
        
            this.gameObject.transform.position = new Vector3(cameraXaxis,cameraYaxis,-10);
       
    }
}
