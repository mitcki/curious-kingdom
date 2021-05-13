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
        GameObject flames = GameObject.Find("Flame.fla.Flame");
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
            Destroy(gameObject, 2.0f);
            Destroy(other.gameObject);
            GameObject flames = GameObject.Find("Flame.fla.Flame");
            flames.GetComponent<MeshRenderer>().enabled = true;
            flames.GetComponent<SwfClipController>().Play(false);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
