using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; public float smoothTime = 0.003F; private Vector3 velocity = Vector3.zero;
    void Start () {
     transform.position = new Vector3 (target.transform.position.x,
                                       target.transform.position.y, 
                                       transform.position.z);
 }
 
 void Update () {
     transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    // transform.position = new Vector3 (target.transform.position.x,
    //                                    target.transform.position.y, 
    //                                    transform.position.z);
     transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
 }
}
