using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
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
            GameObject replay = GameObject.Find("Replay");
            replay.GetComponent<SpriteRenderer>().enabled = true;
            replay.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
