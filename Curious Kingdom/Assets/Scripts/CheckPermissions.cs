using UnityEngine;
using UnityEngine.iOS;
using System.Collections;

// Show WebCams and Microphones on an iPhone/iPad.
// Make sure NSCameraUsageDescription and NSMicrophoneUsageDescription
// are in the Info.plist.

public class CheckPermissions : MonoBehaviour
{
    IEnumerator Start()
    {
        findWebCams();

        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.Log("webcam found");
            PlayerPrefs.SetInt("CameraPermission", 1);
            GameObject levelLoader = GameObject.Find("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel("ARScene");
        }
        else
        {
            Debug.Log("webcam not found");
            AudioSource voAudio = GameObject.Find("AudioControls").GetComponent<AudioSource>();
            AudioSources clips = GameObject.Find("AudioControls").GetComponent<AudioSources>();
            voAudio.clip = clips.AudioFiles[3];
            voAudio.Play();
            ScanAudio.noCamPanel.SetActive(true);
        }

        // findMicrophones();

        // yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        // if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        // {
        //     Debug.Log("Microphone found");
        // }
        // else
        // {
        //     Debug.Log("Microphone not found");
        // }
    }

    void findWebCams()
    {
        foreach (var device in WebCamTexture.devices)
        {
            Debug.Log("Name: " + device.name);
        }
    }

    // void findMicrophones()
    // {
    //     foreach (var device in Microphone.devices)
    //     {
    //         Debug.Log("Name: " + device);
    //     }
    // }
}