using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HealthBar : MonoBehaviour
{
    public int currentHealth;
    [SerializeField] public bool NeedInit = true;

    public RectTransform healthBar, Hurt;

    private void Init()
    {
        currentHealth = 200;
        Hurt.sizeDelta = new Vector2(currentHealth, Hurt.sizeDelta.y);
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);

        NeedInit = false;

    }
    void Update() {

        if (NeedInit) Init();

        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);

        // Debug.Log(currentHealth);

        if (Hurt.sizeDelta.x > healthBar.sizeDelta.x) {
            Hurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 10;
        }
    }

}