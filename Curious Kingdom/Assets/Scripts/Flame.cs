using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FTRuntime;
using FTRuntime.Yields;

public class Flame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(hideFlame());
    }
    IEnumerator hideFlame()
    {
        yield return new WaitForSeconds(0.25f);
        GetComponent<MeshRenderer>().enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
