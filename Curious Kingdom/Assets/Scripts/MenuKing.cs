using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKing : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 6;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pos);

        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {

            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                GameObject levelLoader = GameObject.Find("LevelLoader");

                if(PlayerPrefs.GetInt("UnlockedKing") == 0){
                    levelLoader.GetComponent<LevelLoader>().LoadNextLevel("ARScene");
                }
                if(PlayerPrefs.GetInt("UnlockedKing") == 1){
                    levelLoader.GetComponent<LevelLoader>().LoadNextLevel("Intro1");
                }

            }
            else
            {
                // GetComponent<HingeJoint2D>().useMotor = true;
            }
        }
        
    }
}
