using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimaatioSkripti : MonoBehaviour
{

    public Animator Animaattori;
    private NavMeshAgent NavmeshAgent;
    public AseLIsta AV;
    //  private Rigidbody rb;
    //private bool isRunning = false;
    public bool isIdle = true;
    //public float juoksemisAika;
    //  private bool WeaponIsTestPole = false;
    // private bool WeaponIsOneHand = false;
    // private bool WeaponIsTwoHand = false;
    // Start is called before the first frame update
    void Start()
    {
        Animaattori = GetComponent<Animator>();
        NavmeshAgent = GetComponent<NavMeshAgent>();
        
        //  rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //////////////////////////////////////////////
        // Ase IDLE ANIMAATIOT JA JUOKSU//////////////
        //////////////////////////////////////////////

        if (!Animaattori.GetBool("DeathBool") && NavmeshAgent.velocity.x > 0 || NavmeshAgent.velocity.z > 0)
        {
            Animaattori.SetBool("IsRunning", true);
            Animaattori.SetBool("IsIdle", false);
        }
        if (!Animaattori.GetBool("DeathBool") && Animaattori.GetBool("IsRunning")) 
        {
            StartCoroutine(Juokseminen());
        }
        if (Animaattori.GetBool("IsAttacking") && !Animaattori.GetBool("DeathBool") && NavmeshAgent.velocity.x == 0 || NavmeshAgent.velocity.z > 0)
        {
            Animaattori.SetBool("IsRunning", false);
        }
        if (AV.selectedfromList == 0) //&& Animaattori.GetBool("IsIdle"))
        {
            Animaattori.SetBool("WeaponIsTestPole", true);
            Animaattori.SetBool("WeaponIsTwoHand", false);
            Animaattori.SetBool("WeaponIsOneHand", false);
        }
        if (Animaattori.GetBool("WeaponIsTestPole") && Animaattori.GetBool("IsIdle"))
        {
            StartCoroutine(IdlaaminenPole());

        }
        if (AV.selectedfromList == 1) // && Animaattori.GetBool("IsIdle"))
        {
            Animaattori.SetBool("WeaponIsTestPole", false);
            Animaattori.SetBool("WeaponIsTwoHand", false);
            Animaattori.SetBool("WeaponIsOneHand", true);
        }
        if (Animaattori.GetBool("WeaponIsOneHand") && Animaattori.GetBool("IsIdle"))
        {
            StartCoroutine(Idle1H());

        }
        if (AV.selectedfromList == 2) // Animaattori.GetBool("IsIdle"))
        {
            Animaattori.SetBool("WeaponIsTestPole", false);
            Animaattori.SetBool("WeaponIsTwoHand", true);
            Animaattori.SetBool("WeaponIsOneHand", false);
        }
        if (Animaattori.GetBool("WeaponIsTwoHand") && Animaattori.GetBool("IsIdle"))
        {
            StartCoroutine(Idle2H());

        }
    }
    // Ase IDLE ANIMAATIOT JA JUOKSU


    public IEnumerator Juokseminen()
    {
        if (!Animaattori.GetBool("DeathBool") && Animaattori.GetBool("IsRunning") && !Animaattori.GetBool("IsAttacking") && !Animaattori.GetBool("IsIdle"))
        {
            Animaattori.Play("Running");
            yield return new WaitForSeconds(5f);
        }
        yield return new WaitForSeconds(5f);
        //TurnOffAfterHit.enabled = isActiveAndEnabled;
        // Ase.GetComponent<Animator>().Play("New State");
    }


    public IEnumerator IdlaaminenPole()
    {
        Animaattori.Play("PoleWeaponIdle");
        yield return new WaitForSeconds(5f);
    }

    public IEnumerator Idle1H()
    {
        Animaattori.Play("1hIdle");
        yield return new WaitForSeconds(5f);
    }

    public IEnumerator Idle2H()
    {
        Animaattori.Play("2hIdle");
        yield return new WaitForSeconds(5f);
    }
}
//////////////////////////////////////////////
// Ase IDLE ANIMAATIOT JA JUOKSU//////////////
//////////////////////////////////////////////