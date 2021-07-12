using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Music : MonoBehaviour
{
    public AudioClip[] MusicFiles;
    private static int lastScene = 1000;
    public static Music player;
    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Music.player = gameObject.GetComponent<Music>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusic(int musicID)
    {
        if(Music.lastScene != musicID){
            Music.lastScene = musicID;
            
            StartCoroutine(FadeAudioSource.StartFade(gameObject.GetComponent<AudioSource>(), 1.0f, 0f));
            StartCoroutine(PlayNextTrack(1.0f, musicID));
        }
        
    }
    IEnumerator PlayNextTrack(float waitTime, int musicID){
        yield return new WaitForSeconds(waitTime);

        gameObject.GetComponent<AudioSource>().clip = MusicFiles[musicID];
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().loop = true;

        StartCoroutine(FadeAudioSource.StartFade(gameObject.GetComponent<AudioSource>(), 1.0f, 0.5f));


    }
    public void StopMusic()
    {
        Music.lastScene = 1000;
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
