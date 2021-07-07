using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FTRuntime;
using FTRuntime.Yields;

public class DiningRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowMap());
        StartCoroutine(HideObjects());
        if(Music.player){
            Music.player.StopMusic();
        }
    }
    IEnumerator HideObjects()
    {
        yield return new WaitForSeconds(0.05f);
        GameObject kingPt2 = GameObject.Find("KING_SEQ19.fla.KING_SEQ19");
        kingPt2.GetComponent<MeshRenderer>().enabled = false;

        GameObject kingPt1 = GameObject.Find("KING_SEQ16-18.fla.KING_SEQ16_18");
        kingPt1.GetComponent<MeshRenderer>().enabled = false;

        GameObject queenPt2 = GameObject.Find("QUEEN_SEQ19.fla.QUEEN_SEQ19");
        queenPt2.GetComponent<MeshRenderer>().enabled = false;

    }

    IEnumerator ShowMap()
     {
        yield return new WaitForSeconds(27f);
        
        GameObject dungeonMap = GameObject.Find("dungeon-map");
        dungeonMap.GetComponent<SpriteRenderer>().enabled = true;

        StartCoroutine(NextScene());

     }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(5f);

        GameObject dungeonMap = GameObject.Find("dungeon-map");
        dungeonMap.GetComponent<SpriteRenderer>().enabled = false;

        GameObject kingPt1 = GameObject.Find("KING_SEQ16-18.fla.KING_SEQ16_18");
        kingPt1.GetComponent<MeshRenderer>().enabled = false;
        GameObject kingPt2 = GameObject.Find("KING_SEQ19.fla.KING_SEQ19");
        kingPt2.GetComponent<MeshRenderer>().enabled = true;
        kingPt2.GetComponent<AudioSource>().Play();
        kingPt2.GetComponent<SwfClipController>().Play(false);

        GameObject queenPt1 = GameObject.Find("QUEEN_SEQ16.fla.QUEEN_SEQ16");
        queenPt1.GetComponent<MeshRenderer>().enabled = false;
        GameObject queenPt2 = GameObject.Find("QUEEN_SEQ19.fla.QUEEN_SEQ19");
        queenPt2.GetComponent<MeshRenderer>().enabled = true;
        queenPt2.GetComponent<AudioSource>().Play();
        queenPt2.GetComponent<SwfClipController>().Play(false);

        StartCoroutine(LoadDungeonGame());

    }

    IEnumerator LoadDungeonGame()
    { 
        yield return new WaitForSeconds(16f);

        GameObject levelLoader = GameObject.Find("LevelLoader");
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel("DungeonIntro");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
