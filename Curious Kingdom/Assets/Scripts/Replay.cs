using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Replay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
            {
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
                {
                    GoodItem.randomVeggie = "";
                    Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                }
            }
        
    }
}
