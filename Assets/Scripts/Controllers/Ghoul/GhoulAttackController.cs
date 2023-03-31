using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhoulAttackController : MonoBehaviour
{
    public float minAttackValidTime = 0.7f;
    public float attackLoopTime = 1.4f;
    float attackTrigggerDistance;
    Animator animator;
    NavMeshAgent agent;
    private float attatckDuration = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        attackTrigggerDistance = GetComponent<GhoulRunController>().attackTrigggerDistance;
        animator = GetComponent<Animator>(); 
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("attack", false);
        GameObject player = GameObject.Find("viking");
        // // Get the direction from the object to the player
        Vector3 direction = player.transform.position - transform.position;
        if(direction.sqrMagnitude > attackTrigggerDistance) {
            // animator.SetBool("attack", false);
            attatckDuration = 0;
            return;
        }
        animator.SetBool("attack", true);
        var deltaTime = Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
        if (attatckDuration >= attackLoopTime) {
            attatckDuration = 0;
            GameObject.Find("HealthBarController").GetComponent<HealthBar>().currentHealth -= 30;
        }
        else if (attatckDuration < minAttackValidTime && attatckDuration + deltaTime >= minAttackValidTime) {
            GameObject.Find("HealthBarController").GetComponent<HealthBar>().currentHealth -= 30;
        }
        attatckDuration += deltaTime;
    }
}
