using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private float cameraXaxis;
    void Start()
    {
        this.gameObject.transform.position = new Vector2(cameraXaxis, (player1.transform.position.y - player2.transform.position.y) / 2);
    }


    void FixedUpdate()
    {
        cameraXaxis = cameraXaxis + 0.02f;
        if((player1.transform.position.y - player2.transform.position.y) / 2 == 0)
        {
            this.gameObject.transform.position = new Vector3(cameraXaxis,player1.transform.position.y,-10);
        }
        else
        {
            this.gameObject.transform.position = new Vector3(cameraXaxis, Mathf.Abs((player1.transform.position.y - player2.transform.position.y)) / 2,-10);

        }
    }
}
