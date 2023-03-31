using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

[RequireComponent(typeof(Collider))]


public class TriggerEvent : MonoBehaviour
{
    [SerializeField] int wallIndex;
    [SerializeField] GameObject Floor;
    [SerializeField] bool trigger;
    [SerializeField] float offset = 5f;
    // Start is called before the first frame update
    void Start()
    {
        offset = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static int cnt=0;    
    private void OnTriggerEnter(Collider other) {
        if (other.transform.name.Contains("viking") && !trigger) {
            
            GameObject c = Instantiate(Floor);
            c.transform.GetChild(0).GetComponent<TriggerEvent>().trigger = false;
            c.transform.GetChild(1).GetComponent<TriggerEvent>().trigger = false;
            c.transform.GetChild(2).GetComponent<TriggerEvent>().trigger = false;
            c.transform.GetChild(3).GetComponent<TriggerEvent>().trigger = false;
            if (wallIndex == 1) {
                // Debug.Log(c.transform.childCount);
                c.transform.position = this.transform.parent.position + Vector3.forward * offset;
                c.transform.GetChild(2).GetComponent<TriggerEvent>().trigger = true;
                // Destroy(c.transform.GetChild(2).gameObject); 
            }
            else if (wallIndex == 2) {
                // Debug.Log(c.transform.childCount);
                c.transform.position = this.transform.parent.position + Vector3.right * offset;
                c.transform.GetChild(3).GetComponent<TriggerEvent>().trigger = true;
                // Destroy(c.transform.GetChild(3).gameObject);
            }
            else if (wallIndex == 3) {
                // Debug.Log(c.transform.childCount);
                c.transform.position = this.transform.parent.position + Vector3.back * offset;
                c.transform.GetChild(0).GetComponent<TriggerEvent>().trigger = true;
                // Destroy(c.transform.GetChild(0).gameObject);
            }
            else if (wallIndex == 4) {
                // Debug.Log(c.transform.childCount);
                c.transform.position = this.transform.parent.position + Vector3.left * offset;
                c.transform.GetChild(1).GetComponent<TriggerEvent>().trigger = true;
                // Destroy(c.transform.GetChild(1).gameObject);
            }
            trigger = true;
            // Destroy(this.gameObject);
        }
    }
}
