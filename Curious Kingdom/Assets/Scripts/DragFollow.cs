using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFollow : MonoBehaviour
{
    Vector3 initialPos; Vector3 curPos; float speed = 0.03f;
    void Update () {
     if(Input.GetMouseButton(0)){
         curPos = Input.mousePosition;
     }
 }
 void OnMouseDown() {
     initialPos = Input.mousePosition;
 }
 
 void OnMouseDrag() {
     if(curPos.x != initialPos.x ) 
     {
         transform.position = new Vector3(transform.position.x +(curPos.x - initialPos.x) * Time.deltaTime * speed,  transform.position.y +(curPos.y - initialPos.y) * Time.deltaTime * speed, transform.position.z);
     }
 }
}
