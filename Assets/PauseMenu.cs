using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public bool GameIsPaused = false;

    public GameObject Paused;
    public Animator UI;

    public SceneTransitions scenes;


	// Use this for initialization
	void Start () {

        Paused.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
		
	}

    public void Resume()
    {
        Paused.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause()
    {
        UI.SetTrigger("Pause");
        Paused.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
    }
}
