using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public GameObject[] Locks;
    public void LevelBtn(int lvl)
    {
        if (lvl <= PlayerPrefs.GetInt("LastLvl", 1))
        {
            SceneManager.LoadScene(lvl);
        }
    }
    private void Start()
    {
        for (int a = 0; a < PlayerPrefs.GetInt("LastLvl", 1) - 1; a++)
        {
            Locks[a].SetActive(false);
        }
    }
    public void EntryBtn()
    {
        SceneManager.LoadScene(0);
    }
}