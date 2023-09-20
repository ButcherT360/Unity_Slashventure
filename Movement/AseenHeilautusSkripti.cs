using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[System.Serializable]
public class AseenHeilautusSkripti : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ase;
    public float WpnDamage;
    public Collider TurnOffAfterHit;
    public GameObject pelaajanohjaus;
    public PlayerHealth Ph;
    public float aseenheiluimisAika = 0;

    // private EnemyHealth Eh;

    public AudioSource audioSource;
    public GameObject targetGameObject;

    public AnimaatioSkripti AnimS;
    bool heiluu = false;
    public bool heiluukoAse = false;
    private bool CanAttack = false; // kyll‰ k‰ytet‰‰n

    NavMeshAgent meAgent; // kyll‰ k‰ytet‰‰n eks‰ ny n‰‰
    private void Awake()
    {
        if (Ase.CompareTag("Axe1h"))
        {
            WpnDamage = Mathf.Round(UnityEngine.Random.Range(6f, 15f));
        }

        meAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // onko vihollinen hiiren osoittimen kohdalla
        atkcheck();



        if (heiluukoAse == true)
        {
            targetGameObject.GetComponent<AseLIsta>().canChangeWeapon = false;
        }
        if (heiluukoAse == false)
        {
            targetGameObject.GetComponent<AseLIsta>().canChangeWeapon = true;

        }
    }


    // onko vihollinen hiiren osoittimen kohdalla jos on niin voi hyˆk‰t‰

    private void atkcheck()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        // sallii hy‰kk‰yksen kun t‰hd‰t‰‰n vihollista hiirell‰.
        CanAttack = true;
        if (Input.GetMouseButton(1) && hit.collider.tag == "Enemy")
        {

            //pelaajanohjaus.transform.rotation = Quaternion.Inverse(hit.transform.rotation);

            // Laita valittu peliobjekti katsomaan klikattua kohdetta
            // pelaajanohjaus.transform.LookAt(hit.transform.position);

            // ultimate spinning move
            // pelaajanohjaus.transform.Rotate(hit.point);


        }
        // voi hakata tiettyj‰ kohteita
        if (Input.GetMouseButton(0) && (hit.collider.tag == "Enemy" || hit.collider.tag == "EnemyDropRandom" || hit.collider.tag == "Object" || hit.collider.tag == "OctoBro") && heiluukoAse == false)

            heiluu = true;
        if (heiluu == true)
        {
            AnimS.Animaattori.SetBool("IsIdle", false);
            heiluu = false;
            TurnOffAfterHit.enabled = isActiveAndEnabled;
            pelaajanohjaus.transform.LookAt(hit.transform.position);
            StartCoroutine(AseenHeilautus());
        }
        // Nappi jota pohjassa painamlla voi hakata aseella ilmaan
        else if (Input.GetButton("AttackAir") && (Input.GetMouseButton(0) && heiluukoAse == false))
        {

            heiluu = true;
            if (heiluu == true)
            {
                // AnimS.isIdle = false;
                AnimS.Animaattori.SetBool("IsIdle", false);
                heiluu = false;
                TurnOffAfterHit.enabled = isActiveAndEnabled;
                pelaajanohjaus.transform.LookAt(hit.transform.position);
                StartCoroutine(AseenHeilautus());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            // menn‰‰n enemyhealth skriptiin ja vaihdetaan nykyisen aseen damage
            //sitten tehd‰‰n damage ja osuessa soitetaan osumis ‰‰ni
            audioSource.Play();
            TurnOffAfterHit.enabled = !TurnOffAfterHit.enabled;
            collision.gameObject.GetComponent<EnemyHealth>().SubstractHP(WpnDamage);


        }
        else if (collision.gameObject.CompareTag("EnemyDropRandom"))
        {

            // menn‰‰n enemyhealth skriptiin ja vaihdetaan nykyisen aseen damage
            //sitten tehd‰‰n damage ja osuessa soitetaan osumis ‰‰ni
            audioSource.Play();
            TurnOffAfterHit.enabled = !TurnOffAfterHit.enabled;
            collision.gameObject.GetComponent<EnemyHealthScriptDropRandom>().SubstractHP(WpnDamage);

        }
        
        else if (collision.gameObject.CompareTag("Object"))
        {
            audioSource.Play();
            TurnOffAfterHit.enabled = !TurnOffAfterHit.enabled;
            collision.gameObject.GetComponent<ObjectHealthScript>().SubstractHP(WpnDamage);



        }
        else if (collision.gameObject.CompareTag("OctoBro"))
        {
            audioSource.Play();
            TurnOffAfterHit.enabled = !TurnOffAfterHit.enabled;
            collision.gameObject.GetComponent<EnemyHealthScriptDropRandom>().SubstractHP(WpnDamage);



        }
    }


    // animaatiolla heilautetaan asetta
    public IEnumerator AseenHeilautus()
    {
        if (AnimS.Animaattori.GetBool("WeaponIsTestPole"))
        {
            AnimS.Animaattori.SetBool("IsAttacking", true);
            AnimS.Animaattori.Play("AseenHeilautusHahmo");
        }
        // Ase.GetComponent<Animator>().Play("AseenHeilautus");
        if (AnimS.Animaattori.GetBool("WeaponIsOneHand"))
        {
            AnimS.Animaattori.SetBool("IsAttacking", true);
            AnimS.Animaattori.Play("AseenHeilautusHahmo2");
        }
        if (AnimS.Animaattori.GetBool("WeaponIsTwoHand"))
        {
            AnimS.Animaattori.SetBool("IsAttacking", true);
            AnimS.Animaattori.Play("AseenHeilautusHahmo3");
        }
        heiluukoAse = true;
        yield return new WaitForSeconds(aseenheiluimisAika);
        heiluukoAse = false;
        AnimS.Animaattori.SetBool("IsAttacking", false);
        AnimS.Animaattori.SetBool("IsIdle", true);
        //TurnOffAfterHit.enabled = isActiveAndEnabled;
        // Ase.GetComponent<Animator>().Play("New State");
    }

}

