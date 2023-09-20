using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OctobroAttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ase;
    public GameObject Collider;
    public Collider TurnOffAfterHit;
    public float EnemyDamageLowest;
    public float EnemyDamageHighest;
    public float WpnDamageEnemy;
    public float animationAttackTime;
    public PlayerHealth Ph;
    public AudioSource audioSource;
    public AnimaatioSkripti AnimSV;
    bool heiluu = false;
    private bool CanAttack = false; // kyll‰ k‰ytet‰‰n

    NavMeshAgent meAgent; // kyll‰ k‰ytet‰‰n eks‰ ny n‰‰
    private void Awake()
    {
        WpnDamageEnemy = Mathf.Round(Random.Range(EnemyDamageLowest, EnemyDamageHighest));
        meAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AIatkcheck();
    }
    private void OnTriggerEnter(Collider TrigCollision)
    {
        if (TrigCollision.gameObject.CompareTag("Player"))
        {
            CanAttack = true;
            AnimSV.Animaattori.SetBool("IsRunning", false);
            AnimSV.Animaattori.SetBool("IsAttacking", true);
            audioSource.Play();
            // menn‰‰n enemyhealth skriptiin ja vaihdetaan nykyisen aseen damage
            //sitten tehd‰‰n damage
            WpnDamageEnemy = Mathf.Round(Random.Range(EnemyDamageLowest, EnemyDamageHighest));
            TrigCollision.gameObject.GetComponent<PlayerHealth>().SubstractHP(WpnDamageEnemy);
            print(WpnDamageEnemy);
            CanAttack = false;
            // TurnOffAfterHit.enabled = !isActiveAndEnabled;
            
            //print("HITTO");

        }
    }
    private void OnTriggerExit(Collider TrigExitCollision)
    {
        if (TrigExitCollision.CompareTag("Player"))
        {
            CanAttack = false;
            //AnimSV.Animaattori.SetBool("IsAttacking", false);

            // myAgent.SetDestination(myTarget.position);
        }
    }


    /* private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Player"))
         {
             CanAttack = true;
             // menn‰‰n enemyhealth skriptiin ja vaihdetaan nykyisen aseen damage
             //sitten tehd‰‰n damage
             collision.gameObject.GetComponent<PlayerHealth>().SubstractHP(WpnDamageEnemy);
         }
     }
    */

    // animaatiolla heilautetaan asetta
    IEnumerator AseenHeilautus()
    {


        if (CanAttack == true)
        {
            //TurnOffAfterHit.isTrigger = false;
            AnimSV.Animaattori.Play("AseenHeilautus");
            yield return new WaitForSeconds(animationAttackTime);

            AnimSV.Animaattori.SetBool("IsAttacking", false);
            // Ase.GetComponent<Animator>().Play("New State");
        }
    }

    private void AIatkcheck()
    {
        heiluu = true;
        if (heiluu == true)
        {

            heiluu = false;

            //TurnOffAfterHit.enabled = isActiveAndEnabled;
            StartCoroutine(AseenHeilautus());

        }
    }
}
