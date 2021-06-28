using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FTRuntime;
using FTRuntime.Yields;
public class TowerReplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
