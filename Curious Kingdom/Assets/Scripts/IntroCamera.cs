using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FTRuntime;
using FTRuntime.Yields;


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
        if(Music.player){
            Music.player.PlayMusic(2);
        }
        

        StartCoroutine(StartScene());
    }
    IEnumerator StartScene(){
        yield return new WaitForSeconds(0.25f);

        GameObject.Find("CASTLE-BIG_SEQ01_OFFWEGO-new.fla.CASTLE_BIG_SEQ01_OFFWEGO").GetComponent<AudioSource>().Play();
        GameObject.Find("CASTLE-BIG_SEQ01_OFFWEGO-new.fla.CASTLE_BIG_SEQ01_OFFWEGO").GetComponent<SwfClipController>().Play(false);

        GameObject.Find("KING_SEQ01_OFFWEGO.fla.KING_SEQ01_OFFWEGO").GetComponent<AudioSource>().Play();
        GameObject.Find("KING_SEQ01_OFFWEGO.fla.KING_SEQ01_OFFWEGO").GetComponent<SwfClipController>().Play(false);
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
        if(Music.player){
            Music.player.PlayMusic(3);
        }

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

        if(Music.player){
            Music.player.PlayMusic(2);
        }
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
