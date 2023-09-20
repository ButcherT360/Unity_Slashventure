using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class AseLIsta : MonoBehaviour
{
    public List<GameObject> WaponList = new List<GameObject>();

    // public AseenVaihto AseInventory;
    // Ase joka kerätään ja lisätään Arrayhin
    public GameObject weapon;
    public int selectedfromList;
    public bool canChangeWeapon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canChangeWeapon)
        {
            Aseenvaihto3();
        }
    }

    public void Aseenvaihto3()
    {

        try
        {
            if (Input.GetKey(KeyCode.Alpha1) && canChangeWeapon)
            {
                WaponList[selectedfromList].SetActive(false);
                selectedfromList = 0;
                WaponList[selectedfromList].SetActive(true);
            }
            if (WaponList.Count >= 2 && Input.GetKey(KeyCode.Alpha2) && canChangeWeapon)
            {
                WaponList[selectedfromList].SetActive(false);
                selectedfromList = 1;
                WaponList[selectedfromList].SetActive(true);
            }
            if (WaponList.Count >= 3 &&Input.GetKey(KeyCode.Alpha3) && canChangeWeapon)
            {
                WaponList[selectedfromList].SetActive(false);
                selectedfromList = 2;
                WaponList[selectedfromList].SetActive(true);
            }
            if (WaponList.Count >= 4 &&Input.GetKey(KeyCode.Alpha4) && canChangeWeapon)
            {
                WaponList[selectedfromList].SetActive(false);
                selectedfromList = 3;
                WaponList[selectedfromList].SetActive(true);
            }
            if (WaponList.Count >= 5 && Input.GetKey(KeyCode.Alpha5) && canChangeWeapon)
            {
                WaponList[selectedfromList].SetActive(false);
                selectedfromList = 4;
                WaponList[selectedfromList].SetActive(true);
            }
        }
        catch(Exception ex)
        {
            Debug.Log("THATS NOT A WEAPON" + ex.Message);
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WaponList.Add(weapon);
            // Ase joka on kerätty mutta poistetaan maailmasta
            // Destroy(gameObject);
        }
    }
}
