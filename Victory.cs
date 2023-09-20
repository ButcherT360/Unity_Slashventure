using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Victory : MonoBehaviour
{
    public TextMeshProUGUI WinText;
    private void FixedUpdate()
    {

        if (GameObject.FindWithTag("OctoBro") == null)


        WinText.gameObject.SetActive(true);
        WinText.text = "You won the game! Thats Incredible Woah!";

    }
}