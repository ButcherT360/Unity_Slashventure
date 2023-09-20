using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerActive : MonoBehaviour
{
    public GameObject PlayerActive;
    // Start is called before the first frame update
    void Start()
    {
        PlayerActive.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
