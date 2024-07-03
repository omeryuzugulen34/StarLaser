using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLvl", 1));
    }
    public void Btn()
    {
        SceneManager.LoadScene(26);
    }
}