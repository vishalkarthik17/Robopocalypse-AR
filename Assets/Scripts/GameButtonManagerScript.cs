using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonManagerScript : MonoBehaviour
{

    public GameObject preGamePanel;
    public GameObject shootPanel;
    public GameObject TempRobot;
    public Camera ARCam;
    public GameObject infplane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rescanPlane() {
        SceneManager.LoadScene("Level0");
    }

    public void startGame(){
        Transform plane = GameObject.FindGameObjectsWithTag("infplane")[0].transform;
        preGamePanel.SetActive(false);
        Vector3 referencePoint1 = ARCam.transform.position + Camera.main.transform.forward * 11.0f;
        Vector3 referencePoint2 = ARCam.transform.position + Camera.main.transform.forward * 11.0f;
        referencePoint1.y = plane.position.y + 1.0f;
        referencePoint2.y = plane.position.y + 1.0f;
        referencePoint1.x -= 2.0f;
        referencePoint2.x += 2.0f;
        
        Object.Instantiate(TempRobot, referencePoint1,Quaternion.identity);
        Object.Instantiate(TempRobot, referencePoint2, Quaternion.identity);

        shootPanel.SetActive(true);
    }
    public void replayGame() {
        SceneManager.LoadScene("Level0");
    }
}
