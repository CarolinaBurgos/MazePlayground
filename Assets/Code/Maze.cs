using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maze : MonoBehaviour
{
    public Text score;
    private int score_value;

    // Start is called before the first frame update
    void Start()
    {        
        score_value = 0;
        score.text = "Score: " + score_value.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }

    void Move(){           
        if(Input.GetKey(KeyCode.UpArrow)) {   
            var newPos = transform.position;
            newPos.y += 0.075f;
            transform.position = newPos;            
        }
        else if(Input.GetKey(KeyCode.DownArrow)) {
            var newPos = transform.position;
            newPos.y -= 0.075f;
            transform.position = newPos;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) {
            var newPos = transform.position;
            newPos.x -= 0.075f;
            transform.position = newPos;
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            var newPos = transform.position;
            newPos.x += 0.075f;
            transform.position = newPos;
        } 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Maze"))
        {
            print("Juego Terminado " + col.name);            
            UnityEngine.SceneManagement.SceneManager.LoadScene("BadRequest");
        }
        else if (col.CompareTag("Price"))
        {
            print("Price " + col.name);
            score_value = score_value + 1;
            score.text = "Score: " + score_value.ToString(); 
            print(score.text);
            Destroy(col.transform.gameObject);

            if(score_value == 3){
                UnityEngine.SceneManagement.SceneManager.LoadScene("BadRequest");                
            }

            //tail.Add(Instantiate(tailPrefab, tail[tail.Count - 1].position, Quaternion.identity).transform);
            //col.transform.position = new Vector2(Random.Range(horizontalLimits.x, horizontalLimits.y), Random.Range(verticalLimits.x, verticalLimits.y));
        }
    }
}
