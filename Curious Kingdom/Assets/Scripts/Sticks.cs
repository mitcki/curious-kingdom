using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FTRuntime;
using FTRuntime.Yields;

public class Sticks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject flames = GameObject.Find("Pepper Burning Up.fla.PepperBurningUp");
        flames.GetComponent<MeshRenderer>().enabled = false;
    }
private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "GoodItem")
        {
            TowerKing towerKing = GameObject.Find("TowerKing").GetComponent<TowerKing>();
            towerKing.Replay();
        }
        if(other.gameObject.tag == "BadItem")
        {
            Destroy(other.gameObject);
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject flames = GameObject.Find("Pepper Burning Up.fla.PepperBurningUp");
            flames.GetComponent<MeshRenderer>().enabled = true;
            flames.GetComponent<SwfClipController>().Play(false);
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 1.0f);

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
