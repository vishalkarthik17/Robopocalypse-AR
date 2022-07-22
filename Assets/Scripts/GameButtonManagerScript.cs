using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameButtonManagerScript : MonoBehaviour
{
    public GameObject levelCompletePanel;
    public GameObject preGamePanel;
    public GameObject shootPanel;
    public GameObject TempRobot;
    public Camera ARCam;
    public GameObject infplane;
    public TextMeshProUGUI enemyRemText;
    public TextMeshProUGUI timeElapsedText;

    public TextMeshProUGUI thisGameTiming;
    public TextMeshProUGUI bestGameTiming;

    public int totalEnemyCount=2;
    public int curEnemyCount;
    public float timeElapsed;
    public bool increaseTimer;

    

    public void killOneEnemy() {
        curEnemyCount--;
        if (curEnemyCount == 0)
            LevelComplete();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        curEnemyCount=totalEnemyCount;
        timeElapsed = 0f;
        timeElapsedText.SetText(timeElapsed.ToString()+" s");
        enemyRemText.SetText((totalEnemyCount - curEnemyCount).ToString() + " / " + totalEnemyCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        enemyRemText.SetText((totalEnemyCount-curEnemyCount).ToString() + " / " + totalEnemyCount.ToString());
        if (increaseTimer)
        {
            timeElapsed += Time.deltaTime;
            timeElapsedText.SetText(((int)timeElapsed).ToString() + " s");
        }
        
    }

    public void rescanPlane() {
        SceneManager.LoadScene("Level0");
    }

    public void startGame(){
        increaseTimer = true;
        //Transform plane = GameObject.FindGameObjectsWithTag("infplane")[0].transform;
        preGamePanel.SetActive(false);
        Vector3 referencePoint1 = ARCam.transform.position + Camera.main.transform.forward * 11.0f;
        Vector3 referencePoint2 = ARCam.transform.position + Camera.main.transform.forward * 11.0f;
        referencePoint1.y = ARCam.transform.position.y + 1.0f;
        referencePoint2.y = ARCam.transform.position.y + 1.0f;
        referencePoint1.x -= 2.0f;
        referencePoint2.x += 2.0f;
        
        Object.Instantiate(TempRobot, referencePoint1,Quaternion.identity);
        Object.Instantiate(TempRobot, referencePoint2, Quaternion.identity);

        shootPanel.SetActive(true);
    }
    public void reloadLevel()
    {
        SceneManager.LoadScene("Level0");
    }
    public void loadLevelsPage()
    {
        SceneManager.LoadScene("LevelScreen");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LevelComplete() {
        PlayerPrefs.SetInt("Level0Complete",1);
        int HighScore = PlayerPrefs.GetInt("Level0HighScore", -1);
        increaseTimer = false;
        levelCompletePanel.SetActive(true);
        thisGameTiming.SetText(((int)timeElapsed).ToString()+" s");
        if (HighScore == -1)
        {
            PlayerPrefs.SetInt("Level0HighScore", (int)timeElapsed);
            HighScore = (int)timeElapsed;
        }
        else {
            if (HighScore > (int)timeElapsed) {
                PlayerPrefs.SetInt("Level0HighScore", (int)timeElapsed);
                HighScore = (int)timeElapsed;
            }
        }
        bestGameTiming.SetText(HighScore.ToString() + " s");

    }
}
