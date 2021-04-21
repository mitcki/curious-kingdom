﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCount : MonoBehaviour
{
    public int itemCount = 0;
    public int badItemCount = 0;
    public static int totalItems = 0;
    public static int gameLevel = 0;
    public int[] gameLevels;
    // Start is called before the first frame update
    void Start()
    {
        gameLevels = new int[4];

        gameLevels[0] = 1;
        gameLevels[1] = Random.Range(7,13);
        gameLevels[2] = Random.Range(14, 19);
        gameLevels[3] = Random.Range(20,25);
        //  = {1,Random.Range(7,13),Random.Range(14, 19),Random.Range(20,25)}
        // GameObject[] gos;
        // gos = GameObject.FindGameObjectsWithTag("GoodItem");
        // totalItems = gos.Length;

        Debug.Log(gameLevels[1]);
        // totalItems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "GoodItem")
        {
            itemCount++;
            if(itemCount == totalItems){
                Debug.Log("Win");
                StartCoroutine(nextLevel());
                GoodItem.randomVeggie = "";
                totalItems = 0;

            }
        }
        if(other.tag == "BadItem")
        {
            badItemCount++;

        }
        
    }
    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(3);
        if(badItemCount == 0)
        {
            gameLevel++;
            if(gameLevel > 3){
                GameObject levelLoader1 = GameObject.Find("LevelLoader");
                levelLoader1.GetComponent<LevelLoader>().LoadNextLevel("Intro1");
            }
            // SceneManager.LoadScene("TowerGame-"+gameLevel);
            GameObject levelLoader = GameObject.Find("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel("TowerGame-"+gameLevels[gameLevel]);
        } else {
            GameObject replay = GameObject.Find("Replay");
            replay.GetComponent<SpriteRenderer>().enabled = true;
            replay.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "GoodItem") {
            itemCount--;
            Debug.Log(itemCount);
        }        
    }
}
