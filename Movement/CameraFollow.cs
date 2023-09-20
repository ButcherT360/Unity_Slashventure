using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Update()
    {
        // Define a target position above and behind the target transform

        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards that target position
        transform.position = targetPosition;
    }
}