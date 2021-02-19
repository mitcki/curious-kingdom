using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCount : MonoBehaviour
{
    public int itemCount = 0;
    public int badItemCount = 0;
    public static int totalItems = 0;
    public static int gameLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        // GameObject[] gos;
        // gos = GameObject.FindGameObjectsWithTag("GoodItem");
        // totalItems = gos.Length;

        // Debug.Log(totalItems);
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
            if(gameLevel > 16){
                gameLevel = 1;
            }
            SceneManager.LoadScene("TowerGame-"+gameLevel);
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
