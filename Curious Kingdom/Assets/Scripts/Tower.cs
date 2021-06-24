using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FTRuntime;
using FTRuntime.Yields;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Music.player.PlayMusic(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "GoodItem"){
            TowerKing towerKing = GameObject.Find("TowerKing").GetComponent<TowerKing>();
            towerKing.Replay();
        }
    }
}
