using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;


    public IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void Level01()
    {
        sceneName = "Level1";
        StartCoroutine(LoadScene());
    }
    public void Level02()
    {
        sceneName = "Level2";
        StartCoroutine(LoadScene());
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        sceneName = "Menu";
        StartCoroutine(LoadScene());
    }
}
