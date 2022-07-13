using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        healthText.SetText(health.ToString()+"/100");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile") {
            health = health - 5;
            healthText.SetText(health.ToString()+"/100");
            Destroy(other.gameObject);
        }
    }
}
