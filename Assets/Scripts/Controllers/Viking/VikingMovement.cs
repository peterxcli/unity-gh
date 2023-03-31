using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class VikingMovement : MonoBehaviour
{
    [SerializeField] float movingSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    Rigidbody rb;
    Animator animator;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", 0f);
        // animator.SetFloat("speed")

        // ##################################### jump #############################################
        // if (Math.Abs(rb.velocity.y) > 1e-1) animator.SetBool("isJumping", false);
        if (Math.Abs(rb.velocity.y) < 1e-2) {animator.SetBool("isJumping", false);}
        if (Math.Abs(rb.velocity.y) < 1e-2 && Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            animator.SetBool("isJumping", true);
            // if(audioSource.isPlaying) audioSource.Stop();
        }
        // ##################################### jump #############################################

        // ##################################### WASD #############################################
        float boost = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 mD = new Vector3(h, 0, v);
        if (mD.sqrMagnitude > 0) {
            animator.SetFloat("speed", boost);
            if(!audioSource.isPlaying) audioSource.Play();
        }
        else {
            if(audioSource.isPlaying) audioSource.Stop();
        }
        mD = transform.TransformDirection(mD);
        mD *= movingSpeed;
        transform.localPosition += mD * Time.deltaTime * boost;
        // ##################################### WASD #############################################
        
        // if(Input.GetKeyDown(KeyCode.H)){
        //     int health = GameObject.Find("HealthBarController").GetComponent<HealthBar>().currentHealth-=10;
        // }
    }
}
