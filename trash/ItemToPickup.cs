using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToPickup : MonoBehaviour
{

    public AseLIsta AseInventory;
    // Ase joka ker�t��n ja lis�t��n Arrayhin
    public GameObject weapon;
   // public int slot;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // Ase joka on ker�tty mutta poistetaan maailmasta
          
            // Ker�tty ase tulee k�ytt��n arrayssa
           
            AseInventory.WaponList.Add(weapon);
          //  Destroy(gameObject);
        }
    }
}
