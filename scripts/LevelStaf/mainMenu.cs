using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    private bool isPaused  = false;

    public GameObject pauseMenu,deathMenu;

    private void Update()
    {
        if (PlayerHealth.instance.isDead == true)
        {
            deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (PlayerHealth.instance.isDead == false&& !isPaused)
        {
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&& !isPaused&& PlayerHealth.instance.isDead == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused&& PlayerHealth.instance.isDead == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        {
            
        }
    }

    public void Oyna()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainMenu");
    }
    public void Tekrar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Cikis()
    {
        Application.Quit();
    }
}
