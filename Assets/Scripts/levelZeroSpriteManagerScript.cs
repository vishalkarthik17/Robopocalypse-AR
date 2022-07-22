using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelZeroSpriteManagerScript : MonoBehaviour
{
    public Sprite green, red;
    public TextMeshProUGUI L0HS;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Level0Complete", -1) != 1)
            this.gameObject.GetComponent<Image>().sprite = red;
        else {
            this.gameObject.GetComponent<Image>().sprite = green;
            L0HS.SetText(PlayerPrefs.GetInt("Level0HighScore").ToString()+" s");
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
