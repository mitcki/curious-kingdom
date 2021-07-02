using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    AudioSource soundFXSource;
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        soundFXSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other) {
            if(rigidBody.velocity.y < -1.0f){
                soundFXSource.PlayOneShot(soundFXSource.clip);
            }
    }
}
