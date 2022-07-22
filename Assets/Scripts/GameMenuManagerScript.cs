using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuManagerScript : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject CreditsPanel;
    public void Start()
    {
        
    }
    public void OpenSettingsPanel() {
        SettingsPanel.SetActive(true);
        
    }

    public void OpenCreditsPanel() {
        CreditsPanel.SetActive(true);
    }
    public void CloseCreditsPanel() {
        CreditsPanel.SetActive(false);
    }

    public void OpenZapsplat() {
        Application.OpenURL("www.zapsplat.com");
    }

    public void CloseSettingsPanel() {
        SettingsPanel.SetActive(false);
    }
    public void LoadLevelScreen() {
        SceneManager.LoadScene("LevelScreen");
    }
}
