using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // other.GetComponent<Rigidbody2D>().gravityScale = 0;
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        // other.GetComponent<Rigidbody2D>().gravityScale = 1;
        
    }
}
