using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterAI : MonoBehaviour, IDamage

{
    public int health;
    public float speed;
    public UnityEngine.AI.NavMeshAgent _navMeshAgent;
    public float targetDistance;
    private float allowedRange = 5;
    public int attackTrigger;
    public RaycastHit cast;
    public GameObject Player;
    public GameObject Hunter;

    //Rigidbody rb;

    public void TakeDamage()
    {
        health--;
    }

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            targetDistance = cast.distance;
            if (targetDistance < allowedRange)
             {
                  transform.LookAt(Player.transform); 
                  speed = 0.02f; 
        
                   if (attackTrigger == 0)
                  { 
                      transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
                  }
             }
            else
            {
                speed = 0; 
            }
        }
       

        if (attackTrigger == 1)
        {
            speed = 0.0f;
        }

        if (health <= 0)
        {
            Debug.Log("Opps, Hunter is Dead...");
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter()
    {
        attackTrigger = 1;
    }

    void OnTriggerExit()
    {
        attackTrigger = 0;
    }

}
