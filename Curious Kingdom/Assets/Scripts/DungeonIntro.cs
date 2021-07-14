using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FTRuntime;
using FTRuntime.Yields;
public class DungeonIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(StartAnimation());
        StartCoroutine(StopAnimation());
        StartCoroutine(LoadGame());
        
    }
    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(0.25f);

        GameObject kingTorch = GameObject.Find("KING_CASTLE-TORCH_SEQ20.fla.KING_CASTLE_TORCH_SEQ20");
        kingTorch.GetComponent<AudioSource>().Play();
        kingTorch.GetComponent<SwfClipController>().Play(false);

    }
    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(16f);

        GameObject kingTorch = GameObject.Find("KING_CASTLE-TORCH_SEQ20.fla.KING_CASTLE_TORCH_SEQ20");
        kingTorch.GetComponent<AudioSource>().Stop();
        kingTorch.GetComponent<SwfClipController>().Stop(false);

    }
    IEnumerator LoadGame()
     {
        yield return new WaitForSeconds(16.5f);
        GameObject levelLoader = GameObject.Find("LevelLoader");

        levelLoader.GetComponent<LevelLoader>().LoadNextLevel("Dungeon-"+Random.Range(1,5));

     }
    // Update is called once per frame
    void Update()
    {
        
    }
}
