using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public int startDelay;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DelayedAnimation());
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
        StartCoroutine(LoadGameDelay());
     }

     IEnumerator LoadGameDelay()
     {
        yield return new WaitForSeconds(12);
        GameObject paperBall = GameObject.Find("queentopaperball_2");
        paperBall.GetComponent<SpriteRenderer>().enabled = true;
        paperBall.GetComponent<Animator>().enabled = true;

         GameObject levelLoader = GameObject.Find("LevelLoader");
        //  levelLoader.GetComponent<LevelLoader>().LoadNextLevel("TowerGame-1");
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
