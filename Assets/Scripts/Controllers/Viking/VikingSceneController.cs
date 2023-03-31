using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VikingSceneController : MonoBehaviour
{
    public int SceneIndexDestination = 2;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("HealthBarController").GetComponent<HealthBar>().currentHealth <= 0){
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(SceneIndexDestination);
        } 
    }
}
