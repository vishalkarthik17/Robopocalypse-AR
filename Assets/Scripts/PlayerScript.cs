using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public int health;
    public Slider slider;
    public GameObject gameOverPanel;
    public GameObject gameButtonManager;
    public  bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile") {
            health = health - 10;
            if(health>=0 && health<=100)
            slider.value = health;
            Destroy(other.gameObject);
            if (health <= 0 && gameOver==false) {
                gameButtonManager.GetComponent<GameButtonManagerScript>().increaseTimer = false;
                SoundControllerScript.SFXInstance.playGameOver();
                gameOverPanel.SetActive(true);
                gameOver = true;
                
            }
            
        }
    }

  
}
