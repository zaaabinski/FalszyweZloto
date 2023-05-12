using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject instruction;
    public GameObject Pause;
    public GameObject plot;
    bool paused = false;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void ShowPlot()
    {
        plot.SetActive(true);
    }
    public void StartTheGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ShowHowTo()
    {
        instruction.SetActive(true);
    }
    public void HideHowTo()
    {
        instruction.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
        paused = false;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && !paused)
        {
            Time.timeScale = 0f;
            Pause.SetActive(true);
            paused = true;
        }
    }
    public void QuitApck()
    {
        Application.Quit();
    }
}

