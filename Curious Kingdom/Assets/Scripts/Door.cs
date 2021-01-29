using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
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
                GetComponent<HingeJoint2D>().useMotor = false;
            }
            else
            {
                GetComponent<HingeJoint2D>().useMotor = true;
            }
        }
    }
}
