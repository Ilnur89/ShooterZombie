using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent agent;

    public float health = 150f;
    private float speed=3f;
    //public float raydistance = 2f;
    Transform targetplayer;
    public float timeFornewPath;
    private bool incorutine;
   
    void Start()
    {
        targetplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(targetplayer.position, transform.position);
        if (!incorutine)
            StartCoroutine(DoSomething());

   
       if(distance > 1.5f && distance < 15f)
        {
            
            agent.SetDestination(targetplayer.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }
    Vector3 getNewRandomPos()
    {
        float x = Random.Range(400, -400);
        float z = Random.Range(400, -400);
        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }
    IEnumerator DoSomething()
    {
        incorutine = true;
        yield return new WaitForSeconds(timeFornewPath);
        GetNewPath();
        incorutine = false;
    }
    void GetNewPath()
    {
        agent.SetDestination(getNewRandomPos());
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
        Destroy(agent);
    }
    void FaceTarget()
    {
        Vector3 direction = (targetplayer.position - transform.position);
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }
}
