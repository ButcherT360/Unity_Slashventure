using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// Aseenvaihtamiset 1-3 numeroihin?
// Aseiden aktivointi ja deaktivointi kun painaa nappia.
public class AseenVaihto : MonoBehaviour
{
   // public List<Ase> WeaponList = new List<Ase>();
    public GameObject[] Weapons;
    public int selected;
   // public int selectedfromList;
    // player choosable slots
    //blic int slots;

    public bool canChangeWeapon;
    //public Transform pelaaja;
    //private AnimationState WeaponAnimState;
    // Start is called before the first frame update
    void Start()
    {

        //StartCoroutine(GetComponent<AseenHeilautusSkripti>().AseenPalautus());
    }

    // Update is called once per frame
    void Update()
    {

        if (canChangeWeapon)
        {
            aseenvaihto2();
        }
    }



    public void aseenvaihto2()
    {
        // Aseiden vaihto joukosta Weapons
        for (int i = 0; i < Weapons.Length; i++)
        {
            if (Input.GetKey(KeyCode.Alpha1) && canChangeWeapon)
            {
                selected = 0;
                Weapons[i].SetActive(true);
            }
            if (Input.GetKey(KeyCode.Alpha2) && canChangeWeapon)
            {
                selected = 1;
                Weapons[i].SetActive(true);
            }
            if (Input.GetKey(KeyCode.Alpha3) && canChangeWeapon)
            {
                selected = 2;
                Weapons[i].SetActive(true);
            }

            else if (i != selected)
            {
                Weapons[i].SetActive(false);

            }
        }
    }
}

/* Odottajat ei odota 
 * IEnumerator waiter()
  {
      yield return new WaitForSeconds(20);
  } //StartCoroutine(waiter());
}*/
