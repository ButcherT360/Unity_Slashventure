using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isMenuActive = false;
    private bool isHelpActive = false;
    public GameObject mainmenu;
    public GameObject menu;
    public GameObject secondmenu;
    public GameObject HelpMenu;
   // public GameObject Player;
    private SaveData saves = new SaveData();


    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
    /*    if (isHelpActive == false && Input.GetKeyDown(KeyCode.F1) || isHelpActive == false && Input.GetKeyDown(KeyCode.H))
        {
            isHelpActive = true;
            HelpMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (isHelpActive == true && Input.GetKeyDown(KeyCode.F1) || isHelpActive == true && Input.GetKeyDown(KeyCode.H))
        {
            isHelpActive = false;
            HelpMenu.SetActive(false);
            Time.timeScale = 1;

        } */

        if (isMenuActive == false && Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = true;
            menu.SetActive(true);
            //secondmenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (isMenuActive == true && Input.GetKeyDown(KeyCode.Escape) )
        {
            isMenuActive = false;
            menu.SetActive(false);
            secondmenu.SetActive(false);
            HelpMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        mainmenu.SetActive(false);
        
        Time.timeScale = 1;
       
        //saves.LoadFromJson();
    }
    public void LoadGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        mainmenu.SetActive(false);
        saves.LoadFromJson();
       // saves.PlayerPosition = Player.transform.position;
       // saves.Loadtheposition();


    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
