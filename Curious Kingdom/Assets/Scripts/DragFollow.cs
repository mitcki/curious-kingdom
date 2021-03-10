﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFollow : MonoBehaviour
{
    Vector3 initialPos; Vector3 curPos; float speed = 0.01f;
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
        GetComponent<Animator>().Play("KingTorch");
     } 
     if(curPos.x < initialPos.x){
         GetComponent<SpriteRenderer>().flipX = true;
     } else {
         GetComponent<SpriteRenderer>().flipX = false;

     }
 }
 void OnMouseUp() {
     GetComponent<Animator>().Play("KingTorchStand");
        //  GetComponent<Animator>().enabled = false;

 }
}
