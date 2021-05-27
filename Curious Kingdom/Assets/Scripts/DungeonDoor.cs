using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonDoor : MonoBehaviour
{
    public static int gameLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // other.GetComponent<Rigidbody2D>().gravityScale = 0;
        if(other.name == "king_torch" && Ketchup.Found == true){
            Debug.Log("Win");
            StartCoroutine(nextLevel());
        }
    }
    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(1);
        
            gameLevel++;
            if(gameLevel > 1){
                // gameLevel = 1;
                GameObject levelLoader = GameObject.Find("LevelLoader");
                levelLoader.GetComponent<LevelLoader>().LoadNextLevel("DiningEnd");
            }
            Ketchup.Found = false;
            // SceneManager.LoadScene("Dungeon-"+gameLevel);

        
    }
}
