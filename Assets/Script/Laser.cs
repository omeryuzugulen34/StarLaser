using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public Material material;
    LaserBeam beam;
    private void Update()
    {
        Destroy(GameObject.Find("Laser Beam"));
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
    }
    public void Finish()
    {
        if (GameObject.Find("GameManager").GetComponent<GM>().stopcount == false)
        {
            GameObject.Find("GameManager").GetComponent<GM>().stopcount = true;
            Invoke("finish2", 0.65f);
        }
    }
    void finish2()
    {
        FindObjectOfType<GM>().NextLvlCanvas.SetActive(true);
        PlayerPrefs.SetInt("LastLvl", SceneManager.GetActiveScene().buildIndex + 1);
    }
}