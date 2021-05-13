using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FTRuntime;
using FTRuntime.Yields;
public class DragonTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D other) {
        // if(other.gameObject.tag == "GoodItem"){
        //     TowerKing towerKing = GameObject.Find("TowerKing").GetComponent<TowerKing>();
        //     towerKing.Replay();
        // }
        gameObject.GetComponent<SwfClipController>().Play(false);
        GameObject.Destroy(other.gameObject, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
