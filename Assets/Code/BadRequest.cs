using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BadRequest : MonoBehaviour, IPointerClickHandler {
 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Maze");
        else if (eventData.button == PointerEventData.InputButton.Middle)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Maze");
        else if (eventData.button == PointerEventData.InputButton.Right)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Maze");
    }
}
