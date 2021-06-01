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
        foreach (var trackedImage in args.added){
            Debug.Log(trackedImage.name);
            StartCoroutine(HideObjects());
        }
    }
    IEnumerator HideObjects()
    {
        yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Intro1");


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
