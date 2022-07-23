using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startBtn;
    float curTime;
    bool setVisible;
    void Start()
    {
        curTime = 7f;
        setVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        curTime = curTime - Time.deltaTime;
        if (curTime < 0 && !setVisible) {
            startBtn.SetActive(true);
            setVisible = true;
        }
    }
}
