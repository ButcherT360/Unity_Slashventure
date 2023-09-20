using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToPickup : MonoBehaviour
{

    public AseLIsta AseInventory;
    // Ase joka kerätään ja lisätään Arrayhin
    public GameObject weapon;
   // public int slot;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // Ase joka on kerätty mutta poistetaan maailmasta
          
            // Kerätty ase tulee käyttöön arrayssa
           
            AseInventory.WaponList.Add(weapon);
          //  Destroy(gameObject);
        }
    }
}
