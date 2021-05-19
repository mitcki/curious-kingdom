using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FTRuntime;
using FTRuntime.Yields;

public class PickleBasket : MonoBehaviour
{
    public static bool seenOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start pickle basket");

        if(seenOnce == false){
            GameObject castleAnimation = GameObject.Find("CASTLE-ICON_SEQ11.fla.CASTLE_ICON_SEQ11");
            castleAnimation.GetComponent<SwfClipController>().Play(false);
            castleAnimation.GetComponent<AudioSource>().Play();
        } else {
            GameObject.Find("Main Camera").GetComponent<Animator>().enabled =false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
