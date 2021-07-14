using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFollowFullscreen : MonoBehaviour
{
    Vector3 initialPos; Vector3 curPos; float speed = 2f;
    void Update () {
     if(Input.GetMouseButton(0)){
        //  curPos = Input.mousePosition;
     }
 }
 void OnMouseDown() {
     initialPos = transform.position;
 }
 
 void OnMouseDrag() {
    //  if(curPos.x != initialPos.x ) 
    //  {
         curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //  initialPos = transform.position;

        // Vector3 newPos = new Vector3(transform.position.x +(curPos.x - initialPos.x),  transform.position.y +(curPos.y - initialPos.y), transform.position.z);
        Vector3 newPos = new Vector3(curPos.x,  curPos.y, transform.position.z);
        // Vector3 newPos = new Vector3((initialPos.x - curPos.x),  (initialPos.y - curPos.y), transform.position.z);
        // Vector3 newPos = new Vector3(transform.position.x,  transform.position.y , transform.position.z);
        // transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);
        // initialPos = transform.position;
        Vector3 diff =  newPos - gameObject.transform.position;
        // diff.Normalize();
        Debug.Log(diff);

        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if(rb!=null){
            // rb.AddForce(diff*speed, ForceMode2D.Impulse);
            rb.velocity = diff*speed;


        }
        GetComponent<Animator>().Play("KingTorch");
    //  } 
    // if(Mathf.Abs(diff.x) > 0.9f)
    {
        if(curPos.x < gameObject.transform.position.x){
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;

        }
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
