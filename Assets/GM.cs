using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GM : MonoBehaviour
{
    public GameObject NextLvlCanvas;

    public GameObject ActiveReflector;

    public GameObject PausePanel;

    public bool stopcount;

    public void Start()
    {
        
    }
    public void PauseBtn()
    {
        PausePanel.SetActive(true);
    }
    public void PauseExtBtn()
    {
        PausePanel.SetActive(false);
    }
    public void MainMenuBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void LevelsBtn()
    {
        SceneManager.LoadScene(26);
    }
    public void NextLvlBtn()
    {
        stopcount = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
