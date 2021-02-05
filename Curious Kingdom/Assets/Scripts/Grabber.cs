using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public int count = 0;
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
                count++;
                // Debug.Log("Touching Grabber");
                // GameObject cabbage = Instantiate (Resources.Load ("Prefabs/cabbage") as GameObject);
                GameObject cabbage = GameObject.Find("cabbage_"+count);
                cabbage.transform.position = transform.position;
                cabbage.transform.position += new Vector3(0,-0.4f,0);
                cabbage.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
            }

        }
        
    }
}
