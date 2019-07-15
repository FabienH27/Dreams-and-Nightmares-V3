using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject Levels;
    public GameObject Settings;
    public GameObject Menu;


    void Awake()
    {
        Menu = GameObject.Find("Menu");
        //Settings = GameObject.Find("Settings");
        Levels = GameObject.Find("Levels");
        //Settings.SetActive(false);
        Levels.SetActive(false);
        Menu.SetActive(true);
    }
    public void MainMenu()
    {
        Settings.SetActive(false);
        Levels.SetActive(false);
        Menu.SetActive(true);
    }
    /*public void SettingsMenu()
    {
        Settings.SetActive(true);
        Levels.SetActive(false);
        Menu.SetActive(false);
    }*/
    public void LevelsMenu()
    {
        Settings.SetActive(false);
        Levels.SetActive(true);
        Menu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
