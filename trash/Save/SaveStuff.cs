using Newtonsoft.Json;
using System;
using System.IO;
using TMPro;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class SaveStuff : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI SourceDataText;
    [SerializeField]
    private TMP_InputField InputField;


    private Inventory inventory = new Inventory();
    public Inventory PlayerInventory;
    public PlayerHealth PlayerHealth; //= new PlayerHealth();
    private IDataService DataService = new JsonDataService();
    
    private bool EncryptionEnabled;
    private string PlayerData;


    public void ToggleEncryption(bool EncryptionEnabled)
    {
        this.EncryptionEnabled = EncryptionEnabled;
    }

    public void SerializeJson()
    {
        if (DataService.SaveData("/player-stats.json", PlayerHealth.PHealth, EncryptionEnabled))
        {
            DataService.SaveData("/player-test-Inventory.json", inventory, EncryptionEnabled);
            DataService.SaveData("/player-health.json", PlayerHealth, EncryptionEnabled);
            DataService.SaveData("/player-Inventory.json", PlayerInventory, EncryptionEnabled);



            try
            {
                PlayerHealth data = DataService.LoadData<PlayerHealth>("/player-stats.json", EncryptionEnabled);
                InputField.text = "Loaded from file:\r\n" + JsonConvert.SerializeObject(data, Formatting.Indented);
            }
            catch (Exception e)
            {
                Debug.LogError($"Could not read file! Show something on the UI here!");
                InputField.text = "<color=#ff0000>Error reading save file!</color>";
            }
        }
        else
        {
            Debug.LogError("Could not save file! Show something on the UI about it!");
            InputField.text = "<color=#ff0000>Error saving data!</color>";
        }
    }
    public void DeSerializeJson()
    {

    }
    private void Awake()
    {
        SourceDataText.SetText(JsonConvert.SerializeObject(PlayerHealth, Formatting.Indented));
    }

    public void ClearData()
    {
        string path = Application.persistentDataPath + "/player-stats.json";
        if (File.Exists(path))
        {
            File.Delete(path);
            InputField.text = "Loaded data goes here";
        }
    }
}
