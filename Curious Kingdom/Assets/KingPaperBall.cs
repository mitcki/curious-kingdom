﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPaperBall : MonoBehaviour
{
    public GameObject nextKing;
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
        if (message.Equals("ReversedAnimationEnded"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(nextKing);
        }
    }
}
