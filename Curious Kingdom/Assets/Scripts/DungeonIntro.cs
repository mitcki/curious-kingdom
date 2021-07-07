using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FTRuntime;
using FTRuntime.Yields;
public class DungeonIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadGame());
        
    }
    IEnumerator LoadGame()
     {
        yield return new WaitForSeconds(36f);
        GameObject levelLoader = GameObject.Find("LevelLoader");

        levelLoader.GetComponent<LevelLoader>().LoadNextLevel("Dungeon-"+Random.Range(1,5));

     }
    // Update is called once per frame
    void Update()
    {
        
    }
}
