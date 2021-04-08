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
        animator.Play("CameraTruckRight");
        StartCoroutine(LoadGameDelay());
     }

     IEnumerator LoadGameDelay()
     {
        yield return new WaitForSeconds(12);

         GameObject levelLoader = GameObject.Find("LevelLoader");
         levelLoader.GetComponent<LevelLoader>().LoadNextLevel("TowerGame-1");
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
