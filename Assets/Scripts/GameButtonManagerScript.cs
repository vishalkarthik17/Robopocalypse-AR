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
        preGamePanel.SetActive(false);
        Vector3 referencePoint = ARCam.transform.position + Camera.main.transform.forward * 11.0f;
        //Vector3 referencePoint = new Vector3(ARCam.transform.localPosition.x, ARCam.transform.localPosition.y, ARCam.transform.localPosition.z+11.0f);
        Quaternion rot = Quaternion.Inverse(ARCam.transform.rotation);
        rot.z = 0;
        Object.Instantiate(TempRobot, referencePoint,Quaternion.identity);
        
        shootPanel.SetActive(true);
    }
}
