using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 10;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pos);

        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {

            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                SceneManager.LoadScene("Intro1");

            }
            else
            {
                // GetComponent<HingeJoint2D>().useMotor = true;
            }
        }
        
    }
}
