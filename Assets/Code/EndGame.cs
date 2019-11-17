using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndGame : MonoBehaviour, IPointerClickHandler {
    public Text score;
    
    void Start()
    {        
        score.text = "Score: " + Maze.getValue().ToString(); 
    }
 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            UnityEngine.SceneManagement.SceneManager.LoadScene("MazeScene");
        else if (eventData.button == PointerEventData.InputButton.Middle)
            UnityEngine.SceneManagement.SceneManager.LoadScene("MazeScene");
        else if (eventData.button == PointerEventData.InputButton.Right)
            UnityEngine.SceneManagement.SceneManager.LoadScene("MazeScene");
    }
}
