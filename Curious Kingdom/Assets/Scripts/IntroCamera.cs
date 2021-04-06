using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
