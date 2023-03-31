using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuButtonController : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
