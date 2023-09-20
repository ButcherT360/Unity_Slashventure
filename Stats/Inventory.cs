using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    public float RahatInventoryssa;
    public float Kerattyraha;

    public TextMeshProUGUI RahatText;
    // Start is called before the first frame update
    void Start()
    {
        loadInventoryUI();
        RahatText.text = "Gold:" + RahatInventoryssa.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // textHP.text = HP.ToString();
        //print(HP);
        RahatText.text = "Gold:" + RahatInventoryssa.ToString();

    }
    // Rahat talteen
    public float rahansiirto(float raha)
    {
        Kerattyraha = raha;
        RahatInventoryssa += Kerattyraha;
        RahatText.text = "Gold:" + RahatInventoryssa.ToString();
        return raha;
    }

    public void loadInventoryUI()
    {
        RahatText = GameObject.FindWithTag("RAHAT").GetComponent<TextMeshProUGUI>();
    }
}
