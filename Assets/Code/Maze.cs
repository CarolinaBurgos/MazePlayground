﻿using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Maze : MonoBehaviour
{
    public Text score;
    public Text timer;
    public GameObject coin;
    public List<GameObject> lives = new List<GameObject>();

    private static int score_value;    
    private GameObject[] maze;
    private GameObject character;    

    // Start is called before the first frame update
    void Start()
    {        
        score_value = 0;
        score.text = "Score: " + score_value.ToString(); 
        maze = GameObject.FindGameObjectsWithTag("Enemy");
        character = GameObject.FindWithTag("Character");
        
        var coin_position = coin.transform.position;
        coin_position.x = Random.Range(-5.55f, 5.10f);
        coin_position.y = Random.Range(-2.5f, 2.5f);
        coin.transform.position = coin_position; 

        Collide_Prizes(coin.GetComponent<Collider2D>());
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
            newPos.y += 0.070f;
            transform.position = newPos;            
        }
        else if(Input.GetKey(KeyCode.DownArrow)) {
            var newPos = transform.position;
            newPos.y -= 0.070f;
            transform.position = newPos;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) {
            var newPos = transform.position;
            newPos.x -= 0.070f;
            transform.position = newPos;
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            var newPos = transform.position;
            newPos.x += 0.070f;
            transform.position = newPos;
        } 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Maze") | col.CompareTag("Enemy"))
        { 
            if(lives.Count > 0) { //Delete starts that represents the lives of the character             
                GameObject toDestroy = lives[lives.Count - 1]; 
                lives.RemoveAt(lives.Count - 1);  
                Destroy(toDestroy);  
            } 
            
            if(lives.Count == 0) { //Load new scene if the character lose all his lives
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndGameScene");
            }

            //Reset position if the principal object touch the maze
            var newPos = transform.position;
            newPos.x = -4.87f;
            newPos.y = 1.73f;
            transform.position = newPos;
        }
        else if (col.CompareTag("Prize"))
        { //Increase the score and appear a new prize.
            score_value = score_value + 1;
            score.text = "Score: " + score_value.ToString(); 
            
            //Destroy(col.transform.gameObject);
            Collide_Prizes(col);                       
        }
    }

    void Collide_Prizes(Collider2D col){
        var axis_x = Random.Range(-5.55f, 5.10f);
        var axis_y = Random.Range(-2.5f, 2.5f);
        col.transform.position = new Vector2(axis_x, axis_y);
        var flag = 0;
        foreach (GameObject m in maze){
            if(col.bounds.Intersects(m.GetComponent<Collider2D>().bounds)){
                axis_x = Random.Range(-5.55f, 5.10f);
                axis_y = Random.Range(-2.5f, 2.5f);
            } else {
                flag ++;          
            }
        }
        if(flag == maze.Length){
            col.transform.position = new Vector2(axis_x, axis_y);                
        } else {
            Collide_Prizes(col);
        }
    }

    IEnumerator reloadTimer(float reloadTimeInSeconds)
    {
        float counter = reloadTimeInSeconds;

        while (counter > 0.5)
        {
            counter -= Time.deltaTime;
            timer.text = counter.ToString();
            yield return null;
        }
        //Load new scene if the time is over
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndGameScene");
    }

    public static int getValue () {
        return score_value;
    }
}
