using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class ImageRecognition : MonoBehaviour
{
    private ARTrackedImageManager arTrackedImageManager;
    
    private void Awake() {
        arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable() {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable() {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
        
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args){
        foreach (var trackedImage in args.updated){
            Debug.Log(trackedImage.name);
            StartCoroutine(StartGame());
        }
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(7f);
        // PlayerPrefs.SetInt("UnlockedKing", 1);
        SceneManager.LoadScene("Intro1");

    }
    // Start is called before the first frame update
    void Start()
    {
        Music.player.StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
