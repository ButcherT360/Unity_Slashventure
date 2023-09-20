using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetFollow : MonoBehaviour
{
    NavMeshAgent myAgent;
    
    public GameObject Collider;
    public bool paska = false;


    [SerializeField]
    Transform myTarget;
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();

    }
    // Start is called before the first frame update
    void Start()
    {
        Collider = GameObject.FindWithTag("Player");
        myTarget = Collider.transform;
    }

    // Update is called once per frame
    void Update()
    {


        //Go to selected myTarget destination
        if (paska) 
        { 
            myAgent.SetDestination(myTarget.position);
        }
        
    }

    private void OnTriggerEnter(Collider TrigCollision)
    {   // jos on triggeri alueella niin paska on totta
        if (TrigCollision.gameObject.CompareTag("Player"))
        {
            paska = true;
           // myAgent.SetDestination(myTarget.position);
        }
    }
}
