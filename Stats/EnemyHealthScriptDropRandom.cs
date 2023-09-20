using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


[System.Serializable]
public class EnemyHealthScriptDropRandom : MonoBehaviour
{
    private Animator EnemyDeathAnim;
    public GameObject HpUIBar;
    public Slider slider;
    public float EmaxHealth = 100f;
    public float EHealth = 100f;
    private float damage = 1;
    public GameObject[] Components;
    private GameObject player;
    public GameObject axe;
    public int s;
    public float experiencePointsOnDeath = 1;
    public float deathAnimationTime;
    //public GameObject ItemDrop;
    private void Awake()
    {
        EHealth = EmaxHealth;
        slider.value = returnhp();
    }
    // Start is called before the first frame update
    void Start()
    {
        // arvotaan alussa random itemi listasta
        s = Random.Range(0, Components.Length);
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyDeathAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        slider.value = returnhp();
        if (EHealth < EmaxHealth)
        {
            HpUIBar.SetActive(true);
        }
    }
    // nykyiselle aseelle parametri jota kutsutaan sitten se asetetaan damageksi
    public void SubstractHP(float wpndmg)
    {
        damage = wpndmg;
        EHealth -= damage;
        print(EHealth);
        if (EHealth <= 0f)
        {
            Instantiate(Components[s], transform.position, transform.rotation);
            // Tuhotaan ase ettei vihollinen voi kuolleena lyödä
            // tuhotaan collider ettei vihollista voi lyödä kuolleena koska se spawnaa objekteja
            // tuhotaan AI:n seuranta skripti ettei se liiku kuolleena...
            Destroy(axe);
            Destroy(gameObject.GetComponent<TargetFollowAIDoS>());
            Destroy(gameObject.GetComponent<Collider>());
            // Otetaan vihollisesta saatu expa talteen..
            player.GetComponent<ExperienceLevels>().returnExp(experiencePointsOnDeath);
            // EnemyDeathAnim.ResetTrigger("LuurankoTanssiIdle");
            // if (GameObject.FindGameObjectWithTag("OctoBro"))
            //   {
            //      EnemyDeathAnim.applyRootMotion = false;
            //   }
            // EnemyDeathAnim.applyRootMotion = false;
            // Tiggerillä voi animaation aloittaa... tai booleanilla..
            EnemyDeathAnim.SetBool("DeathBool", true);
            EnemyDeathAnim.SetTrigger("Death");
            EnemyDeathAnim.Play("Death");
            // kahden sekunnin kuolemis animaation soittamiseksi.
            Destroy(gameObject, deathAnimationTime);
        }

    }

    public float returnhp()
    {
        return EHealth / EmaxHealth;
    }

}