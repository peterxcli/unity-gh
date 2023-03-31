using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingCollisionEvent : MonoBehaviour
{
    bool onground = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision) {
        if (collision.transform.name == "big_module_01" || collision.transform.name == "big_module_01_floor") {
            onground = true;
            //Debug.Log("on ground =" + collision.transform.name);
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.transform.name == "big_module_01" || collision.transform.name == "big_module_01_floor") {
            onground = false;
            //Debug.Log("not on ground =" + collision.transform.name);
        }
    }
}
