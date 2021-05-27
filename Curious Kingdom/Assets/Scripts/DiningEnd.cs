using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FTRuntime;
using FTRuntime.Yields;
public class DiningEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateTable());
    }
    IEnumerator AnimateTable()
     {
        yield return new WaitForSeconds(11.5f);
        
        GameObject.Find("dining-table").GetComponent<Animator>().enabled = true;
        GameObject.Find("ketchup-dining").GetComponent<Animator>().enabled = true;

        StartCoroutine(BackToMenu());

     }
     IEnumerator BackToMenu()
     {
        yield return new WaitForSeconds(10f);
        GameObject levelLoader = GameObject.Find("LevelLoader");
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel("Menu");

     }
    // Update is called once per frame
    void Update()
    {
        
    }
}
