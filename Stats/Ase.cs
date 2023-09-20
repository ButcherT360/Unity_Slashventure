using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ase
{
    public GameObject name;
    public string wname;
    public int damage;

    public Ase(GameObject newGameObject, string newName, int newDamage)
    {
        name = newGameObject;
        wname = newName;
        damage = newDamage;
    }
}