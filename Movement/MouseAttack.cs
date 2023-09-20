using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float weaponSwingPower;
    public Transform weapon;
    bool swinging = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ListenForInput();
    }
    private void ListenForInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swinging = true;
           
        } 
    }
    private void FixedUpdate() // good practices in physics calculations. found in: Project settings > Time > Fixed Timestep
    {
            //rb.AddForce(transform.up * thrustPower);
       if (swinging)
            {
            rb.AddRelativeTorque(Vector3.forward* weaponSwingPower);
            swinging = false;
            }
            //  
        }
    }

