using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using System;

[Serializable]
public class PlayerHealth : MonoBehaviour
{
    public GameObject HpUIBar;
    // private GameObject HpUIBarStat;
    public Slider slider;
    public float PMaxHealth = 200f;
    public float PHealth = 100f;
    public float EnemyDmg = 1;
    //public ExperienceLevels SaveExperienceLevels;

    private float HealingAmount;

    public TextMeshProUGUI textHPmax;
    public TextMeshProUGUI textHPcurrent;
    // Start is called before the first frame update
    private void Awake()
    {
        loadHealthUI();
        //HpUIBarStat = GameObject.Find("PelaajaHealthbar");
        // HpUIBar = HpUIBarStat;

    }
    void Start()
    {
        //print(HP);
        loadHealthUI();
        textHPmax.text = PMaxHealth.ToString();
        textHPcurrent.text = PHealth.ToString();
    }
    void Update()
    {
        slider.value = returnhp();
        if (PHealth < PMaxHealth)
        {

            HpUIBar.SetActive(true);
        }

        textHPmax.text = PMaxHealth.ToString();
        textHPcurrent.text = PHealth.ToString();
    }
    // palauta health healthbariin ja päivitä se kun healthmaximi kasvaa.
    public void loadHealthUI()
    {
        slider = GameObject.Find("PelaajaHealthbar").GetComponent<Slider>();
        HpUIBar = GameObject.Find("PelaajaHealthbar");
        textHPmax = GameObject.FindWithTag("HEALTHMAXPLAYER").GetComponent<TextMeshProUGUI>();
        textHPcurrent = GameObject.FindWithTag("HEALTHCURRENTPLAYER").GetComponent<TextMeshProUGUI>();
        //textHPcurrent
    }

    public float returnhp()
    {
        textHPmax.text = PMaxHealth.ToString();
        textHPcurrent.text = PHealth.ToString();
        return PHealth / PMaxHealth;
    }
    //vähennä health
    public void SubstractHP(float WpnDamageEnemy)
    {
        EnemyDmg = WpnDamageEnemy;
        PHealth -= EnemyDmg;
        textHPcurrent.text = PHealth.ToString();
        // textHP.text = HP.ToString();
        //print(HP);
        if (PHealth <= 0f)
        {
            Destroy(gameObject, 5);
        }
    }
    // health talteen
    public float IncreaseHP(float HealingItemH)
    {
        // jos Health on ylitse maximin niin ei saa healthia healthpalloista...
        if (PHealth < PMaxHealth)
        {
            HealingAmount = HealingItemH;
            PHealth += HealingAmount;
            textHPcurrent.text = PHealth.ToString();

        }
        return HealingItemH;
    }
}

    /* paska

    public void Save()
    {
        SaveSystem.SavePlayer(this);
        //SaveSystem.SavePlayerExp(SaveExperienceLevels);


    }
    public void Load()
    {
        PlayerData healthdata = SaveSystem.LoadPlayerHealth();
        //PlayerData expdata = SaveSystem.LoadPlayerExp();
        PHealth = healthdata.healthNow;
        PHealth = healthdata.healthMax;

        Vector3 position;
        position.x = healthdata.position[0];
        position.y = healthdata.position[1];
        position.z = healthdata.position[2];
        transform.position = position;
    }
}*/