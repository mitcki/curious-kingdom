﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public int startDelay;
    private Animator animator;
    public GameObject IconCastle;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DelayedAnimation());
        Music.player.StopMusic();

    }

    IEnumerator DelayedAnimation ()
     {
        yield return new WaitForSeconds(startDelay);

        GameObject paperBall = GameObject.Find("king_paperball_6");
        paperBall.GetComponent<SpriteRenderer>().enabled = true;
        paperBall.GetComponent<Animator>().enabled = true;

       GameObject kingSwf = GameObject.Find("KING_SEQ01_OFFWEGO.fla.KING_SEQ01_OFFWEGO");
        kingSwf.GetComponent<MeshRenderer>().enabled = false;


        animator.Play("CameraTruckRight");
        StartCoroutine(ShowQueenDelay());
        StartCoroutine(StartCastleIcon());

        Music.player.PlayMusic(2);

     }
    IEnumerator StartCastleIcon(){
        yield return new WaitForSeconds(1.3f);
        Instantiate(IconCastle);

        
    }
     IEnumerator ShowQueenDelay()
     {
        yield return new WaitForSeconds(13f);
        GameObject paperBall = GameObject.Find("queentopaperball_2");
        paperBall.GetComponent<SpriteRenderer>().enabled = true;
        paperBall.GetComponent<Animator>().enabled = true;

         StartCoroutine(StartLevelDelay());

         Music.player.StopMusic();
     }

     IEnumerator StartLevelDelay()
     {
         yield return new WaitForSeconds(31f);
         GameObject levelLoader = GameObject.Find("LevelLoader");
         levelLoader.GetComponent<LevelLoader>().LoadNextLevel("TowerGame-1");

     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
