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
                GameObject kingAnimation = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
                if(kingAnimation){
                    kingAnimation.GetComponent<SwfClipController>().Play(false);
                }
                GameObject kingAnimation2 = GameObject.Find("KING_JUMP_V2.fla.KING_JUMP_V3");
                if(kingAnimation2){
                    kingAnimation2.GetComponent<SwfClipController>().Play(false);
                }
                GameObject replayKing = GameObject.Find("KING_REPLAY.fla.KING_REPLAY");
                replayKing.GetComponent<MeshRenderer>().enabled = false;

                
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
            replay.GetComponent<BoxCollider2D>().enabled = true;
            GameObject replayKing = GameObject.Find("KING_REPLAY.fla.KING_REPLAY");
            replayKing.GetComponent<MeshRenderer>().enabled = true;
            replayKing.GetComponent<SwfClipController>().Play(false);

            GameObject kingJump = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
            kingJump.GetComponent<MeshRenderer>().enabled = false;


        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "GoodItem") {
            itemCount--;
            Debug.Log(itemCount);
        }        
    }
}
