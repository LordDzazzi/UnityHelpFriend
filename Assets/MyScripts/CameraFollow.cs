using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private float smoothSpeed = 0.2f;
    public Vector3 offset;
    private void LateUpdate()
    {
        Vector3 cameraPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position,cameraPosition,smoothSpeed);
        transform.position = smoothPosition;
    }

    void Update()
    {
        
    }
}
