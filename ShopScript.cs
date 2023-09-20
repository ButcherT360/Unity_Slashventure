using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using UnityEditor;

[System.Serializable]
public class ShopScript : MonoBehaviour
{
    public AseLIsta PlayerWeaponInventory;
    public Inventory PlayerGoldInventory;
    private bool isMenuActive = false;
    public bool isAxeBought = false;
    public bool is2hAxeBought = false;
    public GameObject ShopWindow;
    // public GameObject BaseWeapon;

    public AseenHeilautusSkripti WeaponTobuyUpgrade;
    public AseenHeilautusSkripti WeaponTobuyUpgrade1;
    public AseenHeilautusSkripti WeaponTobuyUpgrade2;
    public Button WeaponUpgradeButton;
    public Button WeaponUpgradeButton1;
    public GameObject WeaponToBuy;
    public GameObject WeaponToBuy2;
    public Button BuyAxe;
    public Button BuyDoubleAxe;

    public TextMeshProUGUI UpgradeAxeText;
    public TextMeshProUGUI UpgradeDoubleAxeText;
    public TextMeshProUGUI textGoldcurrent;
    // Start is called before the first frame update
    void Start()
    {
        WeaponUpgradeButton.gameObject.SetActive(false);
        WeaponUpgradeButton1.gameObject.SetActive(false);
        UpgradeAxeText.text = WeaponTobuyUpgrade1.WpnDamage.ToString();
        UpgradeDoubleAxeText.text = WeaponTobuyUpgrade2.WpnDamage.ToString();
        // WeaponTobuyUpgrade.Ase = WeaponToBuy;
        ShopWindow.SetActive(false);
        textGoldcurrent.text = "Gold: " + PlayerGoldInventory.RahatInventoryssa.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAxeBought)
        {
            BuyAxe.gameObject.SetActive(false);
            WeaponUpgradeButton.gameObject.SetActive(true);
        }
        if (is2hAxeBought)
        {
            BuyDoubleAxe.gameObject.SetActive(false);
            WeaponUpgradeButton1.gameObject.SetActive(true);
        }
        if (isMenuActive == false && Input.GetKeyDown(KeyCode.B))
        {
            isMenuActive = true;
            ShopWindow.SetActive(true);
            Time.timeScale = 0;
        }
        else if (isMenuActive == true && Input.GetKeyDown(KeyCode.B))
        {
            isMenuActive = false;
            ShopWindow.SetActive(false);
            Time.timeScale = 1;
        }
        UpgradeAxeText.text = WeaponTobuyUpgrade1.WpnDamage.ToString();
        UpgradeDoubleAxeText.text = WeaponTobuyUpgrade2.WpnDamage.ToString();

        textGoldcurrent.text = "Gold: " + PlayerGoldInventory.RahatInventoryssa.ToString();
    }

    public void BuyAxeFromShop()
    {
        if (PlayerGoldInventory.RahatInventoryssa >= 500)
        {
            Debug.Log("You have clicked teh button");
            PlayerWeaponInventory.WaponList[1] = WeaponToBuy;
            isAxeBought = true;
            // ReplaceEmptyHands in list
            // PlayerWeaponInventory.WaponList.add(WeaponToBuy);
            BuyAxe.gameObject.SetActive(false);
            PlayerGoldInventory.RahatInventoryssa -= 500;
            WeaponUpgradeButton.gameObject.SetActive(true);
        }
    }
    public void BuyGreatAxeFromShop()
    {
        if (PlayerGoldInventory.RahatInventoryssa >= 1500)
        {

            Debug.Log("You have clicked teh button");
            is2hAxeBought = true;
            PlayerWeaponInventory.WaponList[2] = WeaponToBuy2;
           // PlayerWeaponInventory.WaponList.Insert(2,WeaponToBuy2);
            BuyDoubleAxe.gameObject.SetActive(false);
            PlayerGoldInventory.RahatInventoryssa -= 1500;
            WeaponUpgradeButton1.gameObject.SetActive(true);
        }
    }
    public void UpgradeBaseWeapon()
    {
        if (PlayerGoldInventory.RahatInventoryssa >= 100)
        {
            Debug.Log("You have upgraded your weapon");
            WeaponTobuyUpgrade.WpnDamage += 2;
            PlayerGoldInventory.RahatInventoryssa -= 100;
        }
    }
    public void UpgradeAxeWeapon()
    {
        if (PlayerGoldInventory.RahatInventoryssa >= 200)
        {
            Debug.Log("You have upgraded your weapon");
            WeaponTobuyUpgrade1.WpnDamage += 4;
            UpgradeAxeText.text = WeaponTobuyUpgrade1.WpnDamage.ToString();
            PlayerGoldInventory.RahatInventoryssa -= 200;
        }
    }
    public void UpgradeDoubleAxeWeapon()
    {
        if (PlayerGoldInventory.RahatInventoryssa >= 300)
        {
            Debug.Log("You have upgraded your weapon");
            WeaponTobuyUpgrade2.WpnDamage += 6;
            UpgradeDoubleAxeText.text = WeaponTobuyUpgrade2.WpnDamage.ToString();
            PlayerGoldInventory.RahatInventoryssa -= 300;
        }
    }
}
