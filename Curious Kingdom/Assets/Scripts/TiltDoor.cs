using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltDoor : MonoBehaviour
{
    private bool doorStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Transform touchArea = transform.Find("TouchArea");
        if ((Input.GetMouseButtonDown(0) || Input.touchCount == 1) && doorStarted == false)
        {
            if (touchArea.GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos) || GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                JointMotor2D motor = GetComponent<HingeJoint2D>().motor;
                motor.motorSpeed *= -1;
                motor.maxMotorTorque = 10000;
                GetComponent<HingeJoint2D>().motor = motor;
                StartCoroutine(activateMotor());
                GetComponent<HingeJoint2D>().useMotor = false;
                doorStarted = true;
                StartCoroutine(resetFlag());
                gameObject.GetComponent<AudioSource>().Play();
            }
            else
            {
                // GetComponent<HingeJoint2D>().useMotor = true;
            }
        }
    }
    IEnumerator activateMotor()
    {
        yield return new WaitForSeconds(0.15f);

        GetComponent<HingeJoint2D>().useMotor = true;
    }

    IEnumerator resetFlag()
    {
        yield return new WaitForSeconds(1.0f);

        doorStarted = false;
    }
}
