using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Camera KameraScroll;
    public Transform target;
    public int degrees = 10;


    private void Awake()
    {
        Camera Kamera = GetComponent<Camera>();

    }
    // Update is called once per frame
    void Update()
    {
        // zoom in zoom out
       if (KameraScroll.orthographicSize > 6f && Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            KameraScroll.orthographicSize--;
            print(KameraScroll.orthographicSize); 
        }

        if (KameraScroll.orthographicSize < 8f && Input.GetAxis("Mouse ScrollWheel") < 0f )
        {
            KameraScroll.orthographicSize++;
            print(KameraScroll.orthographicSize);
        }
     
      /*  if (KameraScroll.orthographicSize < 8f && Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
        {
            KameraScroll.orthographicSize += Input.GetAxis("Mouse ScrollWheel");
        }
      */
        if (Input.GetMouseButton(1))
        {

            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * degrees);
     }
    }
}
