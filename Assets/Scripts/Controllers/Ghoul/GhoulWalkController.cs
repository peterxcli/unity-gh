using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class GhoulWalkController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    NavMeshAgent agent;
    public float startChasingDistance = 20f;

    // The speed of the character
    public float speed = 1.0f;

    // The maximum amount of time the character can walk in a single direction before changing direction
    public float maxWalkDuration = 1.0f;
    public Vector2 walkDurationRange = new Vector2(1.0f, 20.0f);

    // The minimum and maximum angles that the character can turn while walking
    public Vector2 turnAngleRange = new Vector2(45.0f, 135.0f);

    // The character's current direction of movement
    private Vector3 moveDirection = Vector3.forward;

    // The time the character has been walking in their current direction
    private float walkDuration = 0.0f;
    
    void Start()
    {
        animator = GetComponent<Animator>(); 
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // animator.SetBool("walk", false);
        GameObject player = GameObject.Find("viking");
        // // Get the direction from the object to the player
        Vector3 direction = player.transform.position - transform.position;

        // // Rotate the object to face the player
        // transform.rotation = Quaternion.LookRotation(direction);
        if(direction.sqrMagnitude <= startChasingDistance) return;

        animator.SetBool("walk", true);
        // Debug.Log("walk: " + direction);
        if(agent.isOnNavMesh) agent.isStopped = true;
        // Update the character's walking duration
        walkDuration += Time.deltaTime;

        // If the character has been walking for longer than the maximum walk duration, change direction
        if (walkDuration > maxWalkDuration)
        {
            // Choose a random angle to turn
            float turnAngle = Random.Range(turnAngleRange.x, turnAngleRange.y);
            maxWalkDuration = Random.Range(walkDurationRange.x, walkDurationRange.y);

            // Rotate the character by the chosen angle around the y-axis
            transform.Rotate(Vector3.up, turnAngle);

            // Reset the character's walking duration
            walkDuration = 0.0f;
        }

        // Move the character in their current direction
        transform.position += transform.TransformDirection(moveDirection) * speed * Time.deltaTime;
    }
}
