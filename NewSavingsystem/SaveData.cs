using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class SaveData : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    public PlayerHealth PlayerHealth = new PlayerHealth();
    public AseLIsta aselista = new AseLIsta();
    public ShopScript Shopping = new ShopScript();
    public EnemyHealthScriptDropRandom BossHealthSave = new EnemyHealthScriptDropRandom();
    public ExperienceLevels ExperienceAndStats = new ExperienceLevels();
    public Vector3 Player;
    public GameObject Player1;
    public GameObject Boss;
    public GameObject loadActivate;
    //public GameObject PlayersSavedPosition;
    //private Vector3 LoadPlayerPosition = new Vector3();
    public Vector3 PlayerPosition;
    public Vector3 BossPosition;
    // WeaponStatsData?
    //[SerializeField]
    //private TextMeshProUGUI PlayerHPCurrentText = new TextMeshProUGUI();

    public AseenHeilautusSkripti Ase1Dmg = new AseenHeilautusSkripti();
    public AseenHeilautusSkripti Ase2Dmg = new AseenHeilautusSkripti();
    public AseenHeilautusSkripti Ase3Dmg = new AseenHeilautusSkripti();

    private void Start()
    {
       // Player1.transform.position = PlayerPosition;
    }

    public void SaveToJson()
    {
        //PlayerHealth.textHPcurrent = PlayerHPCurrentText;
        // PlayerPosition.x = Player.x;
        // PlayerPosition.z = Player.z;
        // PlayerPosition.y = Player.y;
        loadActivate.SetActive(true);
        PlayerPosition = Player1.transform.position;
       // PlayersSavedPosition = Player1.transform;
        BossPosition = Boss.transform.position;
        string inventoryData = JsonUtility.ToJson(inventory);
        string PlayerHealthData = JsonUtility.ToJson(PlayerHealth);
        string PlayerWeaponData = JsonUtility.ToJson(aselista);
        string ShopData = JsonUtility.ToJson(Shopping);
        string ExpStatData = JsonUtility.ToJson(ExperienceAndStats);
        string PlayerPositionData = JsonUtility.ToJson(PlayerPosition);
        string PlayerPositionDataOffline = JsonUtility.ToJson(Player1.transform.position);
        string BossHealthData = JsonUtility.ToJson(BossHealthSave);
        //string PlayerHPTextData = JsonUtility.ToJson(PlayerHPCurrentText);

        string Ase1Data = JsonUtility.ToJson(Ase1Dmg);
        string Ase2Data = JsonUtility.ToJson(Ase2Dmg);
        string Ase3Data = JsonUtility.ToJson(Ase3Dmg);

        string filePathInventory = Application.persistentDataPath + "/InventoryData.json";
        string filePathHealth = Application.persistentDataPath + "/HealthData.json";
        string filePathWeapon = Application.persistentDataPath + "/WeaponData.json";
        string filePathShop = Application.persistentDataPath + "/ShopData.json";
        string fileExpStat = Application.persistentDataPath + "/ExpStatData.json";
        string filePlayerPosition = Application.persistentDataPath + "/PlayerPositionData.json";
        string filePlayerPositionOffline = Application.persistentDataPath + "/PlayerPositionDataOffline.json";
        string fileBossHealth = Application.persistentDataPath + "/BossHealth.json";
       // string filePlayerHealthText = Application.persistentDataPath + "/HealthNowText.json";

        string fileAse1 = Application.persistentDataPath + "/Weapon1Data.json";
        string fileAse2 = Application.persistentDataPath + "/Weapon2Data.json";
        string fileAse3 = Application.persistentDataPath + "/Weapon3Data.json";

        


        Debug.Log(filePathInventory);


        File.WriteAllText(filePathInventory, inventoryData);
        File.WriteAllText(filePathHealth, PlayerHealthData);
        File.WriteAllText(filePathWeapon, PlayerWeaponData);
        File.WriteAllText(filePathShop, ShopData);
        File.WriteAllText(fileExpStat, ExpStatData);
        File.WriteAllText(filePlayerPosition, PlayerPositionData);
        File.WriteAllText(filePlayerPositionOffline, PlayerPositionDataOffline);
        File.WriteAllText(fileBossHealth, BossHealthData);
        //File.WriteAllText(filePlayerHealthText, PlayerHPTextData);

        File.WriteAllText(fileAse1, Ase1Data);
        File.WriteAllText(fileAse2, Ase2Data);
        File.WriteAllText(fileAse3, Ase3Data);
    }

    public void LoadFromJson()
    {
        ExperienceAndStats.StatsWindow.SetActive(true);
        string filePathInventory = Application.persistentDataPath + "/InventoryData.json";
        string filePathHealth = Application.persistentDataPath + "/HealthData.json";
        string filePathWeapon = Application.persistentDataPath + "/WeaponData.json";
        string filePathShop = Application.persistentDataPath + "/ShopData.json";
        string fileExpStat = Application.persistentDataPath + "/ExpStatData.json";
        string filePlayerPosition = Application.persistentDataPath + "/PlayerPositionData.json";
        string filePlayerPositionOffline = Application.persistentDataPath + "/PlayerPositionDataOffline.json";
        string fileBossHealth = Application.persistentDataPath + "/BossHealth.json";
        //string filePlayerHealthText = Application.persistentDataPath + "/HealthNowText.json";

        string inventoryData = File.ReadAllText(filePathInventory);
        string PlayerHealthData = File.ReadAllText(filePathHealth);
        string PlayerWeaponData = File.ReadAllText(filePathWeapon);
        string ShopData = File.ReadAllText(filePathShop);
        string ExpStatData = File.ReadAllText(fileExpStat);
        string PlayerPositionData = File.ReadAllText(filePlayerPosition);
        string PlayerPositionDataOffline = File.ReadAllText(filePlayerPositionOffline);
        string BossHealthData = File.ReadAllText(fileBossHealth);
       // string PlayerHPTextData = File.ReadAllText(filePlayerHealthText);

        string fileAse1 = Application.persistentDataPath + "/Weapon1Data.json";
        string fileAse2 = Application.persistentDataPath + "/Weapon2Data.json";
        string fileAse3 = Application.persistentDataPath + "/Weapon3Data.json";

        string Ase1Data = File.ReadAllText(fileAse1);
        string Ase2Data = File.ReadAllText(fileAse2);
        string Ase3Data = File.ReadAllText(fileAse3);

        JsonUtility.FromJsonOverwrite(Ase1Data, Ase1Dmg);
        JsonUtility.FromJsonOverwrite(Ase2Data, Ase2Dmg);
        JsonUtility.FromJsonOverwrite(Ase3Data, Ase3Dmg);


        // inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        JsonUtility.FromJsonOverwrite(PlayerHealthData, PlayerHealth);
        JsonUtility.FromJsonOverwrite(inventoryData, inventory);
        JsonUtility.FromJsonOverwrite(PlayerWeaponData, aselista);
        JsonUtility.FromJsonOverwrite(ShopData, Shopping);
        JsonUtility.FromJsonOverwrite(ExpStatData, ExperienceAndStats);
        JsonUtility.FromJsonOverwrite(PlayerPositionData, PlayerPosition);
        JsonUtility.FromJsonOverwrite(PlayerPositionDataOffline, Player1.transform.position);
        JsonUtility.FromJsonOverwrite(BossHealthData, BossHealthSave);
        //Player1.transform.position = PlayersSavedPosition.position; 
        //JsonUtility.FromJsonOverwrite(PlayerHPTextData, PlayerHPCurrentText);
        //Player.transform.position.x = PlayerPosition.x 

        // Boss.transform.position = BossPosition;
        //PlayerHealth.HpUIBar = PlayerHealth.HpUIBarStat;
        //PlayerHPCurrentText = PlayerHealth.textHPcurrent;
        PlayerHealth.loadHealthUI();
        inventory.loadInventoryUI();

        SavetoString();


        ExperienceAndStats.LoadExperienceUI();
        ExperienceAndStats.StatsWindow.SetActive(false);
        Loadtheposition();
        Debug.Log("Load!");

    }

    public string SavetoString()
    {
        return JsonUtility.ToJson(this);
    }

    public void Loadtheposition()
    {
          Player = PlayerPosition;
          Player1.transform.position = Player;
    }
}

