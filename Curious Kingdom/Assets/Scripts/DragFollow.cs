using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFollow : MonoBehaviour
{
    Vector3 initialPos; Vector3 curPos; float speed = 2f;
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
        Vector3 newPos = new Vector3(transform.position.x +(curPos.x - initialPos.x),  transform.position.y +(curPos.y - initialPos.y), transform.position.z);
        // transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);
        Vector3 diff = newPos - gameObject.transform.position;
        diff.Normalize();
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if(rb!=null){
            // rb.AddForce(diff*speed, ForceMode2D.Impulse);
            rb.velocity = diff*speed;


        }
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
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if(rb!=null){
            // rb.velocity = new Vector3(0,0,0);

        }

 }
}
