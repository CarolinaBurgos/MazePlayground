using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maze : MonoBehaviour
{
    public Text score;
    public Text timer;
    private static int score_value;    

    // Start is called before the first frame update
    void Start()
    {        
        score_value = 0;
        score.text = "Score: " + score_value.ToString(); 
        StartCoroutine(reloadTimer(30));
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
        { //Reset position if the principal object touch the maze
            var newPos = transform.position;
            newPos.x = -7.61f;
            newPos.y = 3.39f;
            transform.position = newPos;
        }
        else if (col.CompareTag("Prize"))
        { //Increase the score and appear a new prize.
            score_value = score_value + 1;
            score.text = "Score: " + score_value.ToString(); 
            print(score.text);
            //Destroy(col.transform.gameObject);
            /*if(score_value == 3){
                UnityEngine.SceneManagement.SceneManager.LoadScene("BadRequest");                
            }*/
            col.transform.position = new Vector2(Random.Range(-7, 7), Random.Range(4, -5));
        }
    }

    IEnumerator reloadTimer(float reloadTimeInSeconds)
    {
        float counter = reloadTimeInSeconds;

        while (counter > 0)
        {
            counter -= Time.deltaTime;
            timer.text = counter.ToString();
            yield return null;
        }

        //Load new Scene
        //SceneManager.LoadScene(0);
        UnityEngine.SceneManagement.SceneManager.LoadScene("BadRequest");
    }

    public static int getValue () {
        return score_value;
    }
}
