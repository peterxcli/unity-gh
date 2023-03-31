using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class CoinNumController : MonoBehaviour
{
    public RectTransform CoinNumText;
    public int Coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinNumText.GetComponent<TextMeshProUGUI>().text = "coins: $" + Coins;
    }
}
