using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 10f;

    public float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 playerPosition = player.transform.position;
        //Vector3 cameraPosition = transform.position;

        //transform.position = new Vector3(0, cameraPosition.y, playerPosition.z);


        Vector3 playerPosition = player.transform.position;
        Vector3 targetPosition = new Vector3(0, transform.position.y, playerPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
