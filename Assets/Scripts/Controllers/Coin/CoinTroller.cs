using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTroller : MonoBehaviour
{
    public float takeInDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0 , 0 , Time.deltaTime*100);
        if (Input.GetKeyDown(KeyCode.F)) {
            var viking = GameObject.Find("viking");
            var distance = viking.transform.position - transform.position;
            if (distance.sqrMagnitude <= takeInDistance) {
                var coinController = GameObject.Find("CoinNumController");
                coinController.GetComponent<CoinNumController>().Coins ++;
                Destroy(gameObject);
            }
        }
    }
}
