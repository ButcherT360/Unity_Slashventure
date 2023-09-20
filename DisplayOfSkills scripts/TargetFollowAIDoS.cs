using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetFollowAIDoS : MonoBehaviour
{
    private Animator AnimSVAI;
    public NavMeshAgent myAgent;
    private bool seurattava = false;
    // AI hahmon alkuperäinen paikkamuuttuja
    private Vector3 AgentOriginalPosition;
    float rotationSpeed = 12f;
    [SerializeField]
    Transform myTarget;
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        // AI hahmon alkuperäinen paikkamuuttujan asettaminen pelin alkaessa.
        AgentOriginalPosition = myAgent.transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        //Go to selected myTarget destination
        if (seurattava)
        {
            Rotate();
            myAgent.SetDestination(myTarget.position);
            //transform.LookAt(myTarget);
        }
        else if (!seurattava)
        {
            myAgent.SetDestination(AgentOriginalPosition);
        }

    }
    private void OnTriggerStay(Collider TrigCollision)
    {   // jos on triggeri alueella niin seuraa pelaajaa ja seurattava on tosi
        if (TrigCollision.CompareTag("Player"))
        {
            seurattava = true;
           // Rotate();

            // myAgent.SetDestination(myTarget.position);
        }
    }
    // jos ei ole triggeri alueella niin ei seuraa pelaajaa ja seurattava on epätosi
    private void OnTriggerExit(Collider TrigExitCollision)
    {
        if (TrigExitCollision.CompareTag("Player"))
        {
            seurattava = false;
            AnimSVAI.SetBool("IsAttacking", false);
            // myAgent.SetDestination(myTarget.position);
        }
    }


    // rotate animation target???
    void Rotate()
    {
        Vector3 direction = myTarget.position - transform.position;

        if (direction == Vector3.zero)
            return;

        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
