using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FTRuntime;
using FTRuntime.Yields;
public class TowerKing : MonoBehaviour
{
    int kingChance;
    // Start is called before the first frame update
    void Start()
    {
        kingChance = Random.Range(1, 3);
        Debug.Log("kingChance");
        Debug.Log(kingChance);
        StartCoroutine(prepAnimation());
    }
    IEnumerator prepAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        if(kingChance == 1){
            GameObject kingAnimation = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
            kingAnimation.GetComponent<MeshRenderer>().enabled = false;

        } else {
            GameObject kingAnimation = GameObject.Find("KING_JUMP_V2.fla.KING_JUMP_V3");
            kingAnimation.GetComponent<MeshRenderer>().enabled = false;
        }
        GameObject replayKing = GameObject.Find("KING_REPLAY.fla.KING_REPLAY");
        replayKing.GetComponent<MeshRenderer>().enabled = false;

    }
    public void Jump()
    {
        if(kingChance == 1){
            GameObject kingAnimation = GameObject.Find("KING_JUMP_V2.fla.KING_JUMP_V3");
            kingAnimation.GetComponent<SwfClipController>().Play(false);

            GameObject kingAnimation2 = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
            kingAnimation2.GetComponent<MeshRenderer>().enabled = false;

        } else {
            GameObject kingAnimation = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
            kingAnimation.GetComponent<SwfClipController>().Play(false);

            GameObject kingAnimation2 = GameObject.Find("KING_JUMP_V2.fla.KING_JUMP_V3");
            kingAnimation2.GetComponent<MeshRenderer>().enabled = false;
        }
        
    }
    public void Replay()
    {
        GameObject replay = GameObject.Find("Replay");
        replay.GetComponent<BoxCollider2D>().enabled = true;
        GameObject replayKing = GameObject.Find("KING_REPLAY.fla.KING_REPLAY");
        replayKing.GetComponent<MeshRenderer>().enabled = true;
        replayKing.GetComponent<SwfClipController>().Play(false);

        GameObject kingAnimation = GameObject.Find("KING_JUMP_V2.fla.KING_JUMP_V3");
        kingAnimation.GetComponent<MeshRenderer>().enabled = false;
        GameObject kingAnimation2 = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
        kingAnimation2.GetComponent<MeshRenderer>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
