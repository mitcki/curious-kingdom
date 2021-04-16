using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenPaperBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextQueen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    public void AlertObservers(string message)
    {
        if (message.Equals("ReversedAnimationEnded"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(nextQueen);
        }
    }
}
