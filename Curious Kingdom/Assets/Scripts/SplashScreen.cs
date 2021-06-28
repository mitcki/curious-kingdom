using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SplashScreen : MonoBehaviour
{
    public string NextLevel;
    public float WaitTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nextScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator nextScreen()
    {
        yield return new WaitForSeconds(WaitTime);
        GameObject levelLoader = GameObject.Find("LevelLoader");
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel(NextLevel);

    }
}
