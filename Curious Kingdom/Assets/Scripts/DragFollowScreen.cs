using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFollowScreen : MonoBehaviour
{
    public GameObject playerObject;
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
        Vector3 newPos = new Vector3(playerObject.transform.position.x +(curPos.x - initialPos.x),  playerObject.transform.position.y +(curPos.y - initialPos.y), playerObject.transform.position.z);
        // transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);
        Vector3 diff = newPos - playerObject.transform.position;
        diff.Normalize();
        Rigidbody2D rb = playerObject.GetComponent<Rigidbody2D>();
        if(rb!=null){
            // rb.AddForce(diff*speed, ForceMode2D.Impulse);
            rb.velocity = diff*speed;


        }
        playerObject.GetComponent<Animator>().Play("KingTorch");
     } 
     if(curPos.x < initialPos.x){
         playerObject.GetComponent<SpriteRenderer>().flipX = true;
     } else {
         playerObject.GetComponent<SpriteRenderer>().flipX = false;

     }
 }
 void OnMouseUp() {
     playerObject.GetComponent<Animator>().Play("KingTorchStand");
        //  GetComponent<Animator>().enabled = false;
        Rigidbody2D rb = playerObject.GetComponent<Rigidbody2D>();
        if(rb!=null){
            // rb.velocity = new Vector3(0,0,0);

        }

 }
}
