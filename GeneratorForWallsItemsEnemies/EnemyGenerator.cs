using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class EnemyGenerator : MonoBehaviour
{
    public Transform[] Locations;
    public GameObject[] Components;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Locations.Length; i++)
        {
            int s = Random.Range(0, Components.Length);

            Instantiate(Components[s], Locations[i].position, Quaternion.identity);
        }
    }

}