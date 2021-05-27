using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FTRuntime;
using FTRuntime.Yields;

public class Intro3Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public int startDelay;
    private Animator animator;
    public GameObject IconCastle;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DelayedAnimation());
    }

    IEnumerator DelayedAnimation ()
     {
        yield return new WaitForSeconds(startDelay);

        GameObject kingAnimation = GameObject.Find("KING_SEQ13.fla.KING_SEQ13");
        kingAnimation.GetComponent<SwfClipController>().Play(false);
        kingAnimation.GetComponent<AudioSource>().Play();

        


        StartCoroutine(PaperBall());
    //     StartCoroutine(StartCastleIcon());

     }

    IEnumerator PaperBall(){
        yield return new WaitForSeconds(5f);

        GameObject paperBall = GameObject.Find("king_paperball_6");
        paperBall.GetComponent<SpriteRenderer>().enabled = true;
        paperBall.GetComponent<Animator>().enabled = true;

        animator.Play("CameraTruckRight3");


    //    GameObject kingSwf = GameObject.Find("KING_SEQ09.fla.KING_SEQ09");
        GameObject kingAnimation = GameObject.Find("KING_SEQ13.fla.KING_SEQ13");

        kingAnimation.GetComponent<MeshRenderer>().enabled = false;
    }
    IEnumerator StartCastleIcon(){
        yield return new WaitForSeconds(12.5f);
        Instantiate(IconCastle);

        
    }
     IEnumerator ShowQueenDelay()
     {
        yield return new WaitForSeconds(13f);
        // GameObject paperBall = GameObject.Find("queentopaperball_2");
        // paperBall.GetComponent<SpriteRenderer>().enabled = true;
        // paperBall.GetComponent<Animator>().enabled = true;

        //  StartCoroutine(StartLevelDelay());
     }

     IEnumerator StartLevelDelay()
     {
         yield return new WaitForSeconds(31f);
         GameObject levelLoader = GameObject.Find("LevelLoader");
         levelLoader.GetComponent<LevelLoader>().LoadNextLevel("DiningRoom");

     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
