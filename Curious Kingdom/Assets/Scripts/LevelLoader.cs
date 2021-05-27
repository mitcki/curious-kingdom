using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLevel(string SceneName){
        StartCoroutine(LoadLevel(SceneName));
    }

    IEnumerator LoadLevel(string SceneName){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneName);

    }
}
