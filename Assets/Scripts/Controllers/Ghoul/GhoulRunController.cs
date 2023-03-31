using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class GhoulRunController : MonoBehaviour
{
    public float attackTrigggerDistance;
    Animator animator;
    NavMeshAgent agent;
    float startChasingDistance = 0;

    void Start()
    {
        startChasingDistance = GetComponent<GhoulWalkController>().startChasingDistance;
        animator = GetComponent<Animator>(); 
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("run", false);
        GameObject player = GameObject.Find("viking");
        // // Get the direction from the object to the player
        Vector3 direction = player.transform.position - transform.position;

        // // Rotate the object to face the player
        // transform.rotation = Quaternion.LookRotation(direction);
        if(direction.sqrMagnitude > startChasingDistance || direction.sqrMagnitude <= attackTrigggerDistance) {
            if(agent.isOnNavMesh) agent.isStopped = true;
            // animator.SetBool("walk", false);
            animator.SetBool("run", false);
            return;
        }
        animator.SetBool("run", true);
        
        if (GetComponent<HealthBar>().currentHealth <= 0) return;
        transform.rotation = Quaternion.LookRotation(direction);
        try
        {
            if(agent.isOnNavMesh) agent.isStopped = false;
            if(agent.isOnNavMesh) agent.SetDestination(player.transform.position);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
}
