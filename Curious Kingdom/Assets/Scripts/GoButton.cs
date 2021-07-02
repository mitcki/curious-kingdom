using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        // SceneManager.LoadScene(nextScene);
        AudioSource voAudio = GameObject.Find("AudioControls").GetComponent<AudioSource>();
        AudioSources clips = GameObject.Find("AudioControls").GetComponent<AudioSources>();
        voAudio.Stop();
        if(PlayerPrefs.GetInt("CameraPermission") == 0){
            if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                PlayerPrefs.SetInt("CameraPermission", 1);
                GameObject levelLoader = GameObject.Find("LevelLoader");
                levelLoader.GetComponent<LevelLoader>().LoadNextLevel("ARScene");
            
            } else {
                voAudio.clip = clips.AudioFiles[2];
                voAudio.Play();

                ScanAudio.instance.GetComponent<ScanAudio>().StartPermissionsLoad();
            }
            

        } else {
            GameObject levelLoader = GameObject.Find("LevelLoader");
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel("ARScene");
        }
	}
    // IEnumerator loadPermissions(){
    //     yield return new WaitForSeconds(16f);

    //     ScanAudio audioRef = ScanAudio.instance.GetComponent<ScanAudio>();
    //     Instantiate(audioRef.Permissions);
    // }
    // Update is called once per frame
    void Update()
    {
        
    }
}
