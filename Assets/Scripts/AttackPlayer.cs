  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class AttackPlayer : MonoBehaviour
{
    public int health;
    public NavMeshAgent agent;
    public Transform player;
    public float timeBetweenAttacks;
    public bool alreadyAttacked=false; 
    public GameObject Projectile;
    public Slider slider;
    public GameObject gunMuzzle;

    public void setHealth(int newHealth) {
        health = newHealth;
        slider.value = health;
    }
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
        health = 100;
        slider.value = health;
    }
    
    // Update is called once per frame
    void Update()
    {
        AttackPlayerFunction();
        transform.LookAt(player);
    }

    public void AttackPlayerFunction() {
        
        if (!alreadyAttacked) {
            //attack here
            Rigidbody rb = Instantiate(Projectile, gunMuzzle.transform.position,Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce((player.position - gunMuzzle.transform.position) * 150f);
            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() {
        alreadyAttacked = false;

    }
}
