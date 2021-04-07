using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    NavMeshAgent agent;
    
    public float health = 500f;
    public float speed = 2.5f;
    public float raydistance = 2f;
    GameObject targetplayer;
    
    
    private void Start()
    {
        
        targetplayer = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {

        FindTarget();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void FindTarget()
    {
        agent.SetDestination(targetplayer.transform.position);
    }
}
