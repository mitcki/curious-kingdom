using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FTRuntime;
using FTRuntime.Yields;

public class DungeonDoor : MonoBehaviour
{
    public static int gameLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(Music.player){
            Music.player.PlayMusic(5);
        }

        int ketchupNumber = Random.Range(1,5);

        if(ketchupNumber == 1){
            GameObject.Find("ketchup-2").SetActive(false);
            GameObject.Find("ketchup-3").SetActive(false);
            GameObject.Find("ketchup-4").SetActive(false);
        }
        if(ketchupNumber == 2){
            GameObject.Find("ketchup-1").SetActive(false);
            GameObject.Find("ketchup-3").SetActive(false);
            GameObject.Find("ketchup-4").SetActive(false);
        }
        if(ketchupNumber == 3){
            GameObject.Find("ketchup-1").SetActive(false);
            GameObject.Find("ketchup-2").SetActive(false);
            GameObject.Find("ketchup-4").SetActive(false);
        }
        if(ketchupNumber == 4){
            GameObject.Find("ketchup-1").SetActive(false);
            GameObject.Find("ketchup-2").SetActive(false);
            GameObject.Find("ketchup-3").SetActive(false);
        }

        StartCoroutine(StartAnimation());
        

    }
    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(0.25f);

        GameObject kingTorch = GameObject.Find("KING_CASTLE-TORCH_SEQ20.fla.KING_CASTLE_TORCH_SEQ20");
        kingTorch.GetComponent<AudioSource>().Play();
        kingTorch.GetComponent<SwfClipController>().Play(false);

        GameObject.Find("king_torch").GetComponent<SpriteRenderer>().enabled = false;

        GameObject.Find("CameraClose").GetComponent<Camera>().enabled = true;

        StartCoroutine(ZoomOut(4.9f));
        StartCoroutine(HideVignette(5.1f));
        StartCoroutine(ShowVignette(8f));
        StartCoroutine(ZoomIn(9.14f));
        StartCoroutine(ZoomOut(20.6f));
        StartCoroutine(StartGame(20.6f));


    }
    IEnumerator ZoomOut(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("CameraClose").GetComponent<Camera>().enabled = false;
    }
    IEnumerator ZoomIn(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("CameraClose").GetComponent<Camera>().enabled = true;
    }
    IEnumerator StartGame(float time){
        yield return new WaitForSeconds(time);
        GameObject.Find("king_torch").GetComponent<SpriteRenderer>().enabled = true;
        GameObject kingTorch = GameObject.Find("KING_CASTLE-TORCH_SEQ20.fla.KING_CASTLE_TORCH_SEQ20");
        kingTorch.GetComponent<MeshRenderer>().enabled = false;

    }
    IEnumerator HideVignette(float time)
    {
        yield return new WaitForSeconds(time);
        // GameObject.Find("vignette").GetComponent<SpriteRenderer>().enabled = false;
        // GameObject.Find("mask-frame").GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(FadeTo(GameObject.Find("vignette").GetComponent<SpriteRenderer>(), 0, 1));
        StartCoroutine(FadeTo(GameObject.Find("mask-frame").GetComponent<SpriteRenderer>(), 0, 1));

    }
    IEnumerator ShowVignette(float time)
    {
        yield return new WaitForSeconds(time);
        // GameObject.Find("vignette").GetComponent<SpriteRenderer>().enabled = true;
        // GameObject.Find("mask-frame").GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(FadeTo(GameObject.Find("vignette").GetComponent<SpriteRenderer>(), 1, 1));
        StartCoroutine(FadeTo(GameObject.Find("mask-frame").GetComponent<SpriteRenderer>(), 1, 1));


    }
    IEnumerator FadeTo(SpriteRenderer material, float targetOpacity, float duration) {

        // Cache the current color of the material, and its initiql opacity.
        Color color = material.color;
        float startOpacity = color.a;

        // Track how many seconds we've been fading.
        float t = 0;

        while(t < duration) {
            // Step the fade forward one frame.
            t += Time.deltaTime;
            // Turn the time into an interpolation factor between 0 and 1.
            float blend = Mathf.Clamp01(t / duration);

            // Blend to the corresponding opacity between start & target.
            color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

            // Apply the resulting color to the material.
            material.color = color;

            // Wait one frame, and repeat.
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // other.GetComponent<Rigidbody2D>().gravityScale = 0;
        if(other.name == "king_torch" && Ketchup.Found == true){
            Debug.Log("Win");
            StartCoroutine(nextLevel());
            GetComponent<AudioSource>().Play();
        }
    }
    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(1);
        
            gameLevel++;
            if(gameLevel > 1){
                // gameLevel = 1;
                GameObject levelLoader = GameObject.Find("LevelLoader");
                levelLoader.GetComponent<LevelLoader>().LoadNextLevel("DiningEnd");
            }
            Ketchup.Found = false;
            // SceneManager.LoadScene("Dungeon-"+gameLevel);

        
    }
}
