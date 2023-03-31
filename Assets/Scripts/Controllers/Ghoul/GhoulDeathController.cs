using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class GhoulDeathController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    public GameObject goldCoin;
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -50) Destroy(gameObject);
        animator.SetBool("dead", false);
        if (GetComponent<HealthBar>().currentHealth <= 0){
            animator.SetBool("dead", true);
            SetIgnoreRaycastRecursive(gameObject);
            Destroy(transform.GetChild(5).gameObject);
            var coinTransform = transform.position;
            coinTransform.y += 1f;
            
            var renderObject = transform.GetChild(3);
            var meshCollider = renderObject.GetComponent<MeshCollider>();
            meshCollider.enabled = false;
            
            audioSource.Stop();

            Instantiate(goldCoin, coinTransform, Quaternion.Euler(90, 0, 0));
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
            
            foreach(MonoBehaviour script in scripts) {
                script.enabled = false;
            }
            // gameObject.SetActive(false);
        }
    }
    void SetIgnoreRaycastRecursive(GameObject gameObject)
    {
        // Set the game object's layer to "Ignore Raycast"
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        // Recursively call this function for each of the game object's children
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var child = gameObject.transform.GetChild(i);
            SetIgnoreRaycastRecursive(child.gameObject);
        }
    }
}
