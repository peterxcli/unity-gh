using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CoinSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Coin;
    public int Count;

    List<Transform> coinList;
    void Start()
    {
        coinList = new List<Transform>();

        for (int i = 0; i < Count; i++)  {
            Transform c = Instantiate(Coin.transform);
            Transform p = transform.GetChild(Random.Range(0, transform.childCount));

            c.parent = p;
            c.localPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

            coinList.Add(c);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
