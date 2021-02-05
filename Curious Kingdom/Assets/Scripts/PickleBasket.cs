using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickleBasket : MonoBehaviour
{
    public static bool seenOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start pickle basket");

        if(seenOnce == false){
            seenOnce = true;
        } else {
            GameObject.Find("Main Camera").GetComponent<Animator>().enabled =false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
