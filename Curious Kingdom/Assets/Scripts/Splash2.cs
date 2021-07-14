using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
       StartCoroutine(startMusic());
    }
    IEnumerator startMusic(){
        yield return new WaitForSeconds(0.25f);
        Music.player.PlayMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
