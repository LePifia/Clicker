using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Buda", 0);
        PlayerPrefs.SetInt("Counts", 0);
        PlayerPrefs.SetInt("Ilumination", 0);
        PlayerPrefs.SetInt("Inciense", 0);
        PlayerPrefs.SetInt("Ropes", 0);
        PlayerPrefs.SetInt("Sandals", 0);

        PlayerPrefs.SetInt("actualwave", 1);

    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void BossLoadScene()
    {
        SceneManager.LoadScene("BossScene");
    }
}
