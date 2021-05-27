using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FTRuntime;
using FTRuntime.Yields;

public class KingPaperBallDiningRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AlertObservers(string message)
    {
        if (message.Equals("PaperAnimationEnded"))
        {
            GameObject kingPt1 = GameObject.Find("KING_SEQ16-18.fla.KING_SEQ16_18");
            kingPt1.GetComponent<MeshRenderer>().enabled = true;
            // GetComponent<SpriteRenderer>().enabled = false;
            // if(nextKing){
            //     Instantiate(nextKing);
            // }
        }
    }
}
