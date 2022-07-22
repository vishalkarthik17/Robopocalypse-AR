using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuManagerScript : MonoBehaviour
{
    public void ResetProgress() {
        PlayerPrefs.SetInt("Level0Complete", -1);
        PlayerPrefs.SetInt("Level0HighScore", -1);
        PlayerPrefs.SetInt("ismusicmuted",0 );
        PlayerPrefs.SetInt("issfxmuted", 0);
        SceneManager.LoadScene("Menu");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel0() {
        SceneManager.LoadScene("Level0");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    { 
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

}
