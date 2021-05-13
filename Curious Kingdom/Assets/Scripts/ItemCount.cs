using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FTRuntime;
using FTRuntime.Yields;

public class ItemCount : MonoBehaviour
{
    public int itemCount = 0;
    public int badItemCount = 0;
    public static int totalItems = 0;
    public static int gameLevel = 0;
    public static int[] gameLevels;
    // Start is called before the first frame update
    void Start()
    {
        gameLevels = new int[4];

        gameLevels[0] = 1;
        gameLevels[1] = Random.Range(7,13);
        gameLevels[2] = Random.Range(14, 19);
        gameLevels[3] = Random.Range(20,25);

        GameObject flames = GameObject.Find("Flame.fla.Flame");
        flames.GetComponent<MeshRenderer>().enabled = false;
        //  = {1,Random.Range(7,13),Random.Range(14, 19),Random.Range(20,25)}
        // GameObject[] gos;
        // gos = GameObject.FindGameObjectsWithTag("GoodItem");
        // totalItems = gos.Length;

        // Debug.Log(gameLevels[1]);
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
                if(badItemCount == 0){
                    Debug.Log("Win");
                
                    TowerKing towerKing = GameObject.Find("TowerKing").GetComponent<TowerKing>();
                    towerKing.Jump();
                    
                    StartCoroutine(nextLevel());
                    GoodItem.randomVeggie = "";
                    totalItems = 0;
                } else {
                    TowerKing towerKing = GameObject.Find("TowerKing").GetComponent<TowerKing>();
                    towerKing.Replay();

                    GameObject flames = GameObject.Find("Flame.fla.Flame");
                    flames.GetComponent<MeshRenderer>().enabled = true;
                    flames.GetComponent<SwfClipController>().Play(false);

                    GameObject[] GoodItems = GameObject.FindGameObjectsWithTag("GoodItem");
                    for(int i=0; i< GoodItems.Length; i++)
                    {
                        Destroy(GoodItems[i], i*0.5f);
                    }
                    GameObject[] BadItems = GameObject.FindGameObjectsWithTag("BadItem");
                    for(int i=0; i< BadItems.Length; i++)
                    {
                        Destroy(BadItems[i], i*0.5f);
                    }
                }
                

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
            gameLevel++;
            if(gameLevel > 3){
                GameObject levelLoader1 = GameObject.Find("LevelLoader");
                levelLoader1.GetComponent<LevelLoader>().LoadNextLevel("Intro1");
            }
            // SceneManager.LoadScene("TowerGame-"+gameLevel);
            GameObject levelLoader = GameObject.Find("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel("TowerGame-"+gameLevels[gameLevel]);
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "GoodItem") {
            itemCount--;
            Debug.Log(itemCount);
        }        
    }
}
