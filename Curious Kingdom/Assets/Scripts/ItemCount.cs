using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCount : MonoBehaviour
{
    public int itemCount = 0;
    public int totalItems = 0;
    public static int gameLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("GoodItem");
        totalItems = gos.Length;

        
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
            }
        }
        
    }
    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(3);
        gameLevel++;
        SceneManager.LoadScene("TowerGame-"+gameLevel);
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "GoodItem") {
            itemCount--;
            Debug.Log(itemCount);
        }        
    }
}
