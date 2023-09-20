using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject HpUIBar;
    public Slider slider;
    public float EmaxHealth = 100f;
    public float EHealth = 100f;
    public float damage = 1;

    public GameObject ItemDrop;
    private void Awake()
    {
        EHealth = EmaxHealth;
        slider.value = returnhp();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(EHealth < 0f)
        {
            Instantiate(ItemDrop, transform.position, transform.rotation);
            // play death animation
            Destroy(gameObject, 1);
        }
        // textHP.text = HP.ToString();
        //print(HP);
        
    }

    public float returnhp()
    {
        return EHealth / EmaxHealth;
    }
}