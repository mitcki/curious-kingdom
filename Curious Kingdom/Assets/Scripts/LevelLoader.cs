using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public Color BackgroundColor = Color.black;

    void Start() {
        Image bgImage = GameObject.Find("Image").GetComponent<Image>();
        bgImage.color = new Color(BackgroundColor.r, BackgroundColor.g, BackgroundColor.b, 1.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLevel(string SceneName){
        StartCoroutine(LoadLevel(SceneName));
    }

    IEnumerator LoadLevel(string SceneName){
        AudioSource soundEffect = GetComponent<AudioSource>();
        if(soundEffect){
            soundEffect.PlayDelayed(0.5f);
        }
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(SceneName);

    }
}
