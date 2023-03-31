using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class VikingRayCast : MonoBehaviour
{
    Animator animator;
    public float attackValidDistance;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("attack", false);
        // ##################################### ray cast #########################################
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (Input.GetMouseButtonDown(0)) {
            animator.SetBool("attack", true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit)) {
                if (raycastHit.transform.name.Contains("Ghoul") && raycastHit.distance <= attackValidDistance) {
                    var enemy = raycastHit.transform.gameObject;
                    enemy.GetComponent<HealthBar>().currentHealth -= 30;
                    // if (Vector3.Distance(enemy.transform.position, transform.position) > attackValidDistance) {
                        
                    // }
                }
                Debug.Log("ray cast hit " + raycastHit.transform.name);
                if (raycastHit.transform.name.Contains("Viking_Shield_Coin")) {
                    Destroy(raycastHit.transform.gameObject);
                }
            }
        }
        // ##################################### ray cast #########################################
    }
}
