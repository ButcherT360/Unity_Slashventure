using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealthScript : MonoBehaviour
{
    private Animator ObjectDeathAnim;
    public float OHealth = 100f;
    public float damage = 1;
    // lista johon laitetaan lootattavat prefabit tai itemit
    public GameObject[] Components;
    //public GameObject ItemDrop;
    public int s;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        // arvotaan alussa random itemi listasta
        s = Random.Range(0, Components.Length);
        ObjectDeathAnim = GetComponent<Animator>();
    }

    private void Update()
    {

    }
    // nykyiselle aseelle parametri jota kutsutaan sitten se asetetaan damageksi
    public void SubstractHP(float wpndmg)
    {
        damage = wpndmg;
        OHealth -= damage;
        print(OHealth);
        if (OHealth < 0f)
        {


            // play death animation
            Instantiate(Components[s], transform.position, transform.rotation);
            Destroy(gameObject.GetComponent<Collider>());
            ObjectDeathAnim.Play("Death");
            gameObject.tag = "Untagged";
            // Destroy(gameObject, 1);

            // instantiate item to pick up
        }
        // textHP.text = HP.ToString();
        //print(HP);

    }
}