using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using System;

[Serializable]
public class ExperienceLevels : MonoBehaviour
{
    // player level
    public int level = 0;
    public int skillpoints;
    public int vitality = 10;
  //  public float strength = 10;
    public int agility = 10;
    //public int magic = 10;
    // attained experience
    public float experience;
    // current experience on player
    public float TheExperience;
    // Experience for next level
    public float ExpNextLevel = 100;
    private PlayerHealth GetHealth;

    public Button IncreaseStat;
   // public Button IncreaseStatStr;
    public Button IncreaseStatAgi;
    public GameObject StatsWindow;
    public GameObject XpUIBar;
    public Slider slider;
    public TextMeshProUGUI LevelCurrent;
    public TextMeshProUGUI LevelCurrentSkillPointsScreen;
    public TextMeshProUGUI textEXPmax;
    public TextMeshProUGUI textEXPcurrent;
    public TextMeshProUGUI textSkillPoints;
    public TextMeshProUGUI textVitality;
   // public TextMeshProUGUI textStrength;
    // public AseenHeilautusSkripti AseSTR;
    public TextMeshProUGUI textAgility;
    NavMeshAgent AgiAgent;
    // Start is called before the first frame update



    void Start()
    {
        LoadExperienceUI();
       
        GetHealth = GetComponent<PlayerHealth>();
        AgiAgent = GetComponent<NavMeshAgent>();
        // IncreaseStat.onClick.AddListener(AddStat);
        // alussa stats ikkuna on ep‰aktiivinen
        StatsWindow.SetActive(false);
        textVitality.text = vitality.ToString();
      //  textStrength.text = strength.ToString();
        textAgility.text = agility.ToString();


        level = 1;
        LevelCurrent.text = "Level: " + level.ToString();
        LevelCurrentSkillPointsScreen.text = "Level: " + level.ToString();
        textEXPmax.text = ExpNextLevel.ToString();
        textEXPcurrent.text = TheExperience.ToString();

    }
    void Update()
    {
        slider.value = returnExpToBar();
        if (TheExperience >= ExpNextLevel)
        {
            levelup();
            TheExperience = 0;
            ExpNextLevel += 100;
            XpUIBar.SetActive(true);
        }


        if (StatsWindow.activeSelf == false && Input.GetKeyDown(KeyCode.K) || StatsWindow.activeSelf == false && Input.GetKeyDown(KeyCode.S))
        {
            StatsWindow.SetActive(true);
            Time.timeScale = 0;
        }
        else if (StatsWindow.activeSelf == true && Input.GetKeyDown(KeyCode.K) || StatsWindow.activeSelf == true && Input.GetKeyDown(KeyCode.S))
        {
            StatsWindow.SetActive(false);
            Time.timeScale = 1;
        }

        textSkillPoints.text = skillpoints.ToString();
        textEXPmax.text = ExpNextLevel.ToString();
        textEXPcurrent.text = TheExperience.ToString();
        textAgility.text = agility.ToString();
        textVitality.text = vitality.ToString();
    }

    public float returnExp(float exp)
    {
        experience = exp;
        TheExperience += experience;
        return exp;
    }
    public float returnExpToBar()
    {
        textEXPmax.text = ExpNextLevel.ToString();
        textEXPcurrent.text = TheExperience.ToString();
        return TheExperience / ExpNextLevel;
    }
        public void LoadExperienceUI()
     {

         IncreaseStat = GameObject.FindWithTag("VITALITY").GetComponent<Button>();
        //    IncreaseStatStr = GameObject.Find("STRENGTH").GetComponent<Button>(); 
         IncreaseStatAgi = GameObject.FindWithTag("AGILITY").GetComponent<Button>(); 
         slider = GameObject.FindWithTag("XPUIBAR").GetComponent<Slider>();
         StatsWindow = GameObject.FindWithTag("STATSPANEL");
         XpUIBar = GameObject.FindWithTag("EXPOVERBAR");
         LevelCurrent = GameObject.FindWithTag("LEVELCURRENT").GetComponent<TextMeshProUGUI>();
         LevelCurrentSkillPointsScreen = GameObject.FindWithTag("LEVELCURRENTSKILLPOINTSWINDOW").GetComponent<TextMeshProUGUI>();
         textEXPmax = GameObject.FindWithTag("EXPMAX").GetComponent<TextMeshProUGUI>();
         textEXPcurrent = GameObject.FindWithTag("EXPCURRENT").GetComponent<TextMeshProUGUI>();
         textSkillPoints = GameObject.FindWithTag("SKILLPOINTSAMOUNT").GetComponent<TextMeshProUGUI>();
         textVitality = GameObject.FindWithTag("VITALITYNUMBERS").GetComponent<TextMeshProUGUI>();
       //  textStrength = GameObject.FindWithTag("STRENGTHNUMBERS").GetComponent<TextMeshProUGUI>();
         textAgility = GameObject.FindWithTag("AGILITYNUMBERS").GetComponent<TextMeshProUGUI>();
     }

    public void levelup()
    {
        // Lis‰t‰‰n pelaajan leveli‰ ja annetaan healthia
        // Miten lis‰t‰‰n muita statseja ?? teht‰v‰
        if (level != 60)
        {
            level++;
            LevelCurrent.text = "Level: " + level.ToString();
            LevelCurrentSkillPointsScreen.text = "Level: " + level.ToString();
            skillpoints += 5;
            textSkillPoints.text = skillpoints.ToString();

            GetHealth.PHealth = GetHealth.PMaxHealth;
            //GetHealth = GetComponent<PlayerHealth>().PMaxHealth;


            //lvlText.text = level.toString("");
        }
    }


    // Health lis‰ys for now
    public void AddStat()
    {
        if (skillpoints > 0 && vitality != 99)
        {
            Debug.Log("You have clicked teh button");
            skillpoints -= 1;
            textSkillPoints.text = skillpoints.ToString();
            vitality += 1;
            textVitality.text = vitality.ToString();
            GetHealth.PMaxHealth += 12;
            //GetComponent<PlayerHealth>().PMaxHealth += 12;
        }
    }
  /* public void AddStatStr()
    {
        if (skillpoints > 0)
        {
            Debug.Log("You have clicked teh button");
            skillpoints -= 1;
            textSkillPoints.text = skillpoints.ToString();
            strength += 1;
            textStrength.text = strength.ToString();

            // increase base damage only works on single weapon, not sure how to implement...
            // AseSTR.WpnDamage += strength;
        }
    }*/
   
    public void AddStatAgi()
    {
        if (skillpoints > 0 && agility != 99)
        {
            Debug.Log("You have clicked teh button");
            skillpoints -= 1;
            textSkillPoints.text = skillpoints.ToString();
            agility += 1;
            textAgility.text = agility.ToString();
            AgiAgent.speed += 0.5f;
            AgiAgent.acceleration += 0.2f;
            // increase player speed
        }
    }
}
