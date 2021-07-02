using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioClip[] SFXFiles;

    public static SFX player;
    // Start is called before the first frame update
    void Start()
    {
        SFX.player = gameObject.GetComponent<SFX>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(int sfxID)
    {
        // if(!gameObject.GetComponent<AudioSource>().isPlaying){
            gameObject.GetComponent<AudioSource>().clip = SFXFiles[sfxID];
            gameObject.GetComponent<AudioSource>().Play();
        // }
        
    }
    public void StopMusic()
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
