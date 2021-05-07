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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "GoodItem"){
            // replay.GetComponent<SpriteRenderer>().enabled = true;
            GameObject replay = GameObject.Find("Replay");
            replay.GetComponent<BoxCollider2D>().enabled = true;
            GameObject replayKing = GameObject.Find("KING_REPLAY.fla.KING_REPLAY");
            replayKing.GetComponent<MeshRenderer>().enabled = true;
            replayKing.GetComponent<SwfClipController>().Play(false);

            GameObject kingJump = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
            kingJump.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
