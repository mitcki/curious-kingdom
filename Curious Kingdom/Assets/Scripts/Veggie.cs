using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veggie : MonoBehaviour
{
    // Start is called before the first frame updat
    AudioSource soundFXSource;
    Rigidbody2D rigidBody;
    void Start()
    {
        soundFXSource = gameObject.GetComponent<AudioSource>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != "Grabber" && other.gameObject.tag != "BadItem" && soundFXSource)
        {
            if(rigidBody.velocity.y < -1.0f){
                soundFXSource.PlayOneShot(soundFXSource.clip, Mathf.Min(Mathf.Abs(rigidBody.velocity.y*0.1f), 1.0f));
            }
        }
    }
}
